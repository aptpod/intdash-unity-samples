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
public class intdash_RoutePlayback : MonoBehaviour
{
    [SerializeField]
    private string dataType = "10";
    [SerializeField]
    private string dataName = "1/location";

    [SerializeField]
    [IntdashLabel("Node IDÅiEdge UUIDÅj")]
    private string nodeId = "";

    public RouteParts TargetComponent;

    // MEMO: Basically, IntdashPlaybackManager attachment from Inspector is not required, but can be specified.
    [SerializeField] private IntdashPlaybackManagerSample playback;

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
        var playbackId = playback.RegisterBulkPlaybackData(nodeId, filter, OnReceiveBulkPlaybackData);
    }

    private void OnDestroy() { }

    // After playback starts, data within the period set in the IntdashPlaybackManagerSample can be sequentially acquired.
    // Refer to IntdashPlaybackManagerSample.RequestBulkDataDuration for the period to request at a time.
    private void OnReceiveBulkPlaybackData(Pb.DataResponseProto[] dataPoints)
    {
        Debug.Log($"OnReceiveBulkPlaybackData {dataPoints.Length} points - intdash_RoutePlayback");
        try
        {
            foreach (var point in dataPoints)
            {
                var time = point.Time.ToDateTime();
                var data = point.DataPayload.ToByteArray();
                // Once data is received, the necessary data is extracted from the data format and visualized.
                byte[] payload;
                {
                    var len = (int)data[0];
                    payload = new byte[data.Length - (1 + len)];
                    Array.Copy(data, (1 + len), payload, 0, payload.Length);
                }
                var locationData = System.Text.Encoding.UTF8.GetString(payload);
                // Json Parse
                var location = Vector3.zero;
                {
                    JObject json = JObject.Parse(locationData);
                    location.x = json["x"].ToObject<float>();
                    location.z = json["z"].ToObject<float>();
                }
                // Visualize
                if (TargetComponent != null)
                {
                    TargetComponent.AddPoint(location, time.Ticks);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to deserialize location message. " + e.Message);
        }
    }
}
