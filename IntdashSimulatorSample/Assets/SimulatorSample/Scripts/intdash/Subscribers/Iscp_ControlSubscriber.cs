using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

/**
 * Control DataFormat ( string -> JSON )
 * "{
 *   "steering" : 0.0,
 *   "accel" : 0.0,
 *   "footbrake" : 0.0,
 *   "handbrake" : 0.0
 * }"
 */
public class Iscp_ControlSubscriber : MonoBehaviour
{
    [SerializeField]
    private string dataType = "string/json";
    [SerializeField]
    private string dataName = "v1/1/control";

    [SerializeField]
    [IntdashLabel("Node IDiEdge UUIDj")]
    private string nodeId = "";

    public CarIscpControl TargetComponent;

    [SerializeField]
    private string receivedTime;
    public string ReceivedTime => receivedTime;

    [SerializeField]
    private string receivedData;
    public string ReceivedData => receivedData;

    [SerializeField] private float steering;
    public float Steering => steering;
    [SerializeField] private float accel;
    public float Accel => accel;
    [SerializeField] private float footbrake;
    public float Footbrake => footbrake;
    [SerializeField] private float handbrake;
    public float Handbrake => handbrake;

    // MEMO: Basically, IscpConnection attachment from Inspector is not required, but can be specified.
    [SerializeField] private IscpConnection iscp;

    private IscpDownstream downstream;

    // Called when the script is first activated.
    private void Awake()
    {
        // Setup iSCP.
        if (this.iscp == null)
        {
            this.iscp = IscpConnection.GetOrCreateSharedInstance();
        }
        // Register downstream.
        downstream = this.iscp.RegisterDownstream(nodeId, dataName, dataType, OnReceiveDataPoints);
    }

    // Received data points events.
    private void OnReceiveDataPoints(DateTime baseTime, iSCP.Model.DataPointGroup group)
    {
        Dispatcher.RunOnMainThread(() =>
        {
            if (this == null) return;
            if (!this.enabled) return;
            try
            {
                foreach (var d in group.DataPoints)
                {
                    receivedTime = DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss.ffffff");
                    // Extract the necessary data from the data format.
                    var controlData = System.Text.Encoding.UTF8.GetString(d.Payload);
                    receivedData = controlData;
                    // Json Parse
                    {
                        JObject json = JObject.Parse(controlData);
                        steering = json["steering"].ToObject<float>();
                        accel = json["accel"].ToObject<float>();
                        footbrake = json["footbrake"].ToObject<float>();
                        handbrake = json["handbrake"].ToObject<float>();
                    }
                    // Move Vehicles
                    if (TargetComponent != null)
                    {
                        if (TargetComponent.enabled)
                        {
                            TargetComponent.Move(steering, accel, footbrake, handbrake);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to deserialize control message. " + e.Message);
            }
        });
    }

    private void OnEnable() { }

    private void OnDisable() { }
}
