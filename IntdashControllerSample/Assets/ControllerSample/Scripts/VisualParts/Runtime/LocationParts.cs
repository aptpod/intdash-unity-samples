using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationParts : MonoBehaviour
{
    [SerializeField] private Iscp_LocationSubscriber iscpSubscriber;

    private string prevReceivedTime;

    // Update is called once per frame
    void Update()
    {
        if (iscpSubscriber != null)
        {
            if (iscpSubscriber.ReceivedTime == prevReceivedTime) return;
            prevReceivedTime = iscpSubscriber.ReceivedTime;
            var pos = this.transform.position;
            pos.x = iscpSubscriber.X;
            pos.z = iscpSubscriber.Z;
            this.transform.position = pos;
            var rot = this.transform.eulerAngles;
            rot.y = iscpSubscriber.Head;
            this.transform.eulerAngles = rot;
        }
    }
}
