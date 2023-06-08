using UnityEngine;
using iSCP.Model;

/**
 * Control DataFormat ( string -> JSON )
 * "{
 *   "steering" : 0.0,
 *   "accel" : 0.0,
 *   "footbrake" : 0.0,
 *   "handbrake" : 0.0
 * }"
 */
public class Iscp_ControlPublisher : MonoBehaviour, IIscpUpstreamCallbacks
{
    [SerializeField]
    private string dataType = "string";
    [SerializeField]
    private string dataName = "v1/1/control";

    [SerializeField]
    private bool persist;

    public float SamplingRate = 15f;
    private float? _SamplingRate;

    private float elapsedTime = 0;
    private float targetTime = 0;

    public float Steering;
    public float Accel;
    public float Footbrake;
    public float Handbrake;

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

    void Update()
    {
        // Time management so that transmission can be performed at the desired sampling rate.
        if (SamplingRate != _SamplingRate)
        {
            _SamplingRate = SamplingRate;
            this.targetTime = 1f / SamplingRate;
            this.elapsedTime = 0f;
        }

        if (SamplingRate <= 0) return;

        elapsedTime += Time.deltaTime;

        if (this.elapsedTime > this.targetTime)
        {
            this.elapsedTime -= this.targetTime;

            // Generation in accordance with data format.
            var json = "";
            json += "{";
            json += "  \"steering\" : " + Steering + ",";
            json += "  \"accel\" : " + Accel + ",";
            json += "  \"footbrake\" : " + Footbrake + ",";
            json += "  \"handbrake\" : " + Handbrake;
            json += " }";
            var payload = System.Text.Encoding.UTF8.GetBytes(json);
            // Send data points to upstream.
            upstream.SendDataPoint(dataName, dataType, payload);
        }
    }

    private void OnEnable() { }

    private void OnDisable() { }

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
