using UnityEngine;
using iSCP.Model;

/**
 * Location DataFormat ( string -> JSON )
 * "{
 *   "x" : 0.0,
 *   "z" : 0.0,
 *   "head" : 0.0
 * }"
 */
public class Iscp_LocationPublisher : MonoBehaviour, IIscpUpstreamCallbacks
{
    [SerializeField]
    private string dataType = "string/json";
    [SerializeField]
    private string dataName = "v1/1/location";

    [SerializeField]
    private bool persist;

    public LocationSensor InputDevice;

    // MEMO: Basically, IscpConnection attachment from Inspector is not required, but can be specified.
    [SerializeField] private IscpConnection iscp;

    private IscpUpstream upstream;

    // Called when the script is first activated.
    private void Awake()
    {
        // Setup iSCP.
        if (iscp == null)
        {
            this.iscp = IscpConnection.GetOrCreateSharedInstance();
        }
        // Register upstream.
        upstream = iscp.RegisterUpstream(persist);
        upstream.Callbacks = this;
    }

    private void OnEnable()
    {
        if (InputDevice != null)
            InputDevice.OnOutputData += OnOutputData;
    }

    private void OnDisable()
    {
        if (InputDevice != null)
            InputDevice.OnOutputData -= OnOutputData;
    }

    void OnOutputData(LocationSensor.OutputData data)
    {
        // Generation in accordance with data format.
        var json = "";
        json += "{";
        json += "  \"x\" : " + data.Position.x + ",";
        json += "  \"z\" : " + data.Position.z + ",";
        json += "  \"head\" : " + data.Rotation.y;
        json += " }";
        var payload = System.Text.Encoding.UTF8.GetBytes(json);
        // Send data points to upstream.
        upstream.SendDataPoint(dataName, dataType, payload);
    }

    #region IIscpUpstreamCallbacks

    // Called when Upstream opens.
    public void OnOpen(IscpUpstream upstream, string sequenceId)
    {
        if (upstream.Persist)
        {
            // ToDo: If retransmission is performed when data is missing, the data storage process is initiated.
        }
    }

    // Called when data is created in units of sent data.
    public void OnGenerateChunk(IscpUpstream upstream, string sequenceId, UpstreamChunk message)
    {
        if (upstream.Persist)
        {
            // ToDo: When retransmitting data when data is missing, the transmitted data is saved.
        }
    }

    // Called when it is confirmed that the sent data has reached the server correctly.
    public void OnReceiveAck(IscpUpstream upstream, string sequenceId, UpstreamChunkAck message)
    {
        if (upstream.Persist)
        {
            // ToDo: If you want to calculate the missing ratio, do it here.
        }
    }

    #endregion
}
