using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * JPEG DataFormat ( byte array )
 * JPEG Data
 */
public class Iscp_JPEGSubscriber : MonoBehaviour, ITexture2D
{
    [SerializeField]
    private string dataType = "jpeg";
    [SerializeField]
    private string dataName = "v1/1/jpeg";

    [SerializeField]
    [IntdashLabel("Node IDiEdge UUIDj")]
    private string nodeId = "";

    public ImageParts TargetComponent;

    public string ReceivedTime;

    public Texture2D Texture { set; get; }

    // MEMO: Basically, IscpConnection attachment from Inspector is not required, but can be specified.
    [SerializeField] private IscpConnection iscp;

    private IscpDownstream downstream;

    // Called when the script is first activated.
    private void Awake()
    {
        // Setup iSCP
        if (this.iscp == null)
        {
            this.iscp = IscpConnection.GetOrCreateSharedInstance();
        }
        // Register subscriber
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
                    var jpegData = d.Payload;
                    // Decoding and other transformations may be required for visualization.
                    if (Texture == null)
                    {
                        Texture = new Texture2D(2, 2);
                    }
                    Texture.LoadImage(jpegData);
                    Texture.Apply(true, false);
                    // Visualize
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
                    return;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to deserialize jpeg message. " + e.Message);
            }
        });
    }

    private void OnEnable() { }

    private void OnDisable() { }
}
