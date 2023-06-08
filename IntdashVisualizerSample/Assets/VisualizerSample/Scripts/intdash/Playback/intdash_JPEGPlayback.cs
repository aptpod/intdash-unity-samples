using System;
using UnityEngine;

public class intdash_JPEGPlayback : MonoBehaviour
{
    [SerializeField]
    private string dataType = "9";
    [SerializeField]
    private string dataName = "1/jpeg";

    [SerializeField]
    [IntdashLabel("Node IDiEdge UUIDj")]
    private string nodeId = "";

    public ImageParts TargetComponent;

    public string ReceivedTime;

    public Texture2D Texture { set; get; }

    // MEMO: Basically, IntdashPlaybackManager attachment from Inspector is not required, but can be specified.
    [SerializeField] private IntdashPlaybackManagerSample playback;

    private IntdashPlaybackDataCacherSample dataCacher = new IntdashPlaybackDataCacherSample();

    // Called when the script is first activated.
    private void Awake()
    {
        // Setup playback manager.
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
        Debug.Log($"OnReceivePartialPlaybackData {dataPoints.Length} points - intdash_JPEGPlayback");
        foreach (var point in dataPoints)
        {
            var time = point.Time.ToDateTime();
            // Extract the necessary data from the data format.
            var jpegData = point.DataPayload.ToByteArray();
            dataCacher.Add(jpegData, time.Ticks);
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
                if (Texture == null)
                {
                    Texture = new Texture2D(2, 2);
                }
                if (v is byte[] bytes)
                {
                    Texture.LoadImage(bytes);
                }
                else
                {
                    return;
                }
                Texture.Apply(true, false);
                ReceivedTime = new DateTime(t, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm:ss.ffffff");
                // // Visualize
                if (TargetComponent != null)
                {
                    if (TargetComponent.PreviewTexture == null)
                    {
                        if (TargetComponent.gameObject.activeInHierarchy)
                        {
                            TargetComponent.SetPreviewTexture(Texture);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to deserialize jpeg message. " + e.Message);
            }
        });
    }

    private void Playback_OnSetPlaybackTime(long start, long end)
    {
        dataCacher.Clear();
        dataCacher.BaseTime = start;
    }

    private void Playback_OnSeeked(float value, long time)
    {
        // If the seek position returns to the beginning, etc., the position of the data readout function should also be changed.
        dataCacher.SeekTo(time);
    }
}
