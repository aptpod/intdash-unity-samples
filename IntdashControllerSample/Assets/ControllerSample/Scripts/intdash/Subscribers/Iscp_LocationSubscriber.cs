using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

/**
 * Location DataFormat ( string -> JSON )
 * "{
 *   "x" : 0.0,
 *   "z" : 0.0,
 *   "head" : 0.0
 * }"
 */
public class Iscp_LocationSubscriber : MonoBehaviour
{
    [SerializeField]
    private string dataType = "string";
    [SerializeField]
    private string dataName = "v1/1/location";

    [SerializeField]
    [IntdashLabel("Node IDiEdge UUIDj")]
    private string nodeId = "";

    public Transform TargetComponent;

    public string ReceivedTime;

    public string ReceivedData;

    public float X;
    public float Z;
    public float Head;

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
                    ReceivedTime = DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss.ffffff");
                    // Extract the necessary data from the data format.
                    var locationData = System.Text.Encoding.UTF8.GetString(d.Payload);
                    ReceivedData = locationData;
                    // Json Parse
                    {
                        JObject json = JObject.Parse(locationData);
                        X = json["x"].ToObject<float>();
                        Z = json["z"].ToObject<float>();
                        Head = json["head"].ToObject<float>();
                    }
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
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to deserialize location message. " + e.Message);
            }
        });
    }

    private void OnEnable() { }

    private void OnDisable() { }
}
