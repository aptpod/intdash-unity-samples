using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

/// <summary>
/// intdash v1 String Data Format
///       7   6   5   4   3   2   1   0
///     +---+---+---+---+---+---+---+---+
/// 000 | ID Length                     |
///     +---+---+---+---+---+---+---+---+    - - - -
/// 001 | ID                            |      ^
///     +                               +      | ID Length
///     :                               :      |
///     +                               +      |
///     |                               |      v
///     +---+---+---+---+---+---+---+---+    - - - -
///   0 | Data                          |
///     +                               +
///     :                               :
/// </summary>
public class intdash_LocationPlayback : MonoBehaviour
{
    [SerializeField]
    private string dataType = "10";
    [SerializeField]
    private string dataName = "1/location";

    [SerializeField]
    [IntdashLabel("Node IDÅiEdge UUIDÅj")]
    private string nodeId = "";

    public Transform TargetComponent;

    public string ReceivedTime;

    public float X;
    public float Z;
    public float Head;

    // MEMO: Basically, IntdashPlaybackManager attachment from Inspector is not required, but can be specified.
    [SerializeField] private IntdashPlaybackManagerSample playback;

    private IntdashPlaybackDataCacherSample dataCacher = new IntdashPlaybackDataCacherSample();

    private struct Location
    {
        public float X;
        public float Z;
        public float Head;
    }

    // Called when the script is first activated.
    private void Awake()
    {
        // Setup playback manager,
        if (this.playback == null)
        {
            this.playback = IntdashPlaybackManagerSample.GetOrCreateSharedInstance();
        }
        // Register playback data.
        var filter = $"{dataType}:{dataName}";
        var playbackId = playback.RegisterPartialPlaybackData(nodeId, filter, OnReceivePartialPlaybackData);
        // Register an event at seek.
        playback.OnSeeked += Playback_OnSeeked;
        playback.OnSetPlaybackTime += Playback_OnSetPlaybackTime;
    }

    private void OnDestroy()
    {
        playback.OnSeeked -= Playback_OnSeeked;
        playback.OnSetPlaybackTime -= Playback_OnSetPlaybackTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the time to cache data.
        dataCacher.MaxCacheSeconds = playback.MaxCacheSeconds;
    }

    // Data is requested and received sequentially by the PlaybackManager as the playback time advances.
    // For the data reception interval, see IntdashPlaybackManagerSample.RequestPartialDataDuration.
    private void OnReceivePartialPlaybackData(Pb.DataResponseProto[] dataPoints)
    {
        Debug.Log($"OnReceivePartialPlaybackData {dataPoints.Length} points - intdash_LocationPlayback");
        try
        {
            foreach (var point in dataPoints)
            {
                var time = point.Time.ToDateTime();
                var data = point.DataPayload.ToByteArray();
                // Extract the necessary data from the data format.
                byte[] payload;
                {
                    var len = (int)data[0];
                    payload = new byte[data.Length - (1 + len)];
                    Array.Copy(data, (1 + len), payload, 0, payload.Length);
                }
                var locationData = System.Text.Encoding.UTF8.GetString(payload);
                var location = new Location();
                // Json Parse
                {
                    JObject json = JObject.Parse(locationData);
                    location.X = json["x"].ToObject<float>();
                    location.Z = json["z"].ToObject<float>();
                    location.Head = json["head"].ToObject<float>();
                }
                // When data is received, cache the data needed for visualization.
                dataCacher.Add(location, time.Ticks);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to deserialize location message. " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playback.Status == IntdashPlaybackManagerSample.PlaybackStatus.Play)
        {
            CheckPlaybackData();
        }
    }

    private void CheckPlaybackData()
    {
        // Request data close to the current time from cached data.
        var time = playback.CurrentTimeTicks;
        dataCacher.RequestLastData(time, (i, v, t, o) =>
        {
            try
            {
                if (v is Location location)
                {
                    X = location.X;
                    Z = location.Z;
                    Head = location.Head;
                }
                else
                {
                    return;
                }
                ReceivedTime = DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss.ffffff");
                // Visualize
                if (TargetComponent != null)
                {
                    var pos = TargetComponent.transform.position;
                    pos.x = X;
                    pos.z = Z;
                    TargetComponent.transform.position = pos;
                    var rot = TargetComponent.transform.eulerAngles;
                    rot.y = Head;
                    TargetComponent.transform.eulerAngles = rot;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to deserialize location message. " + e.Message);
            }
        });
    }

    private void Playback_OnSetPlaybackTime(long start, long end)
    {
        dataCacher.Clear();
        dataCacher.BaseTime = start;
    }

    private void Playback_OnSeeked(float value, long time, bool dataUpdated)
    {
        // If the seek position returns to the beginning, etc., the position of the data readout function should also be changed.
        if (dataUpdated)
        {
            dataCacher.Clear();
            dataCacher.BaseTime = playback.StartTimeTicks;
        }
        else
        {
            dataCacher.SeekTo(time);
        }
    }
}
