using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationParts : MonoBehaviour
{
    [SerializeField] private Iscp_LocationSubscriber iscpSubscriber;
    [SerializeField] private intdash_LocationPlayback intdashPlayback;

    private void Start()
    {
        if (iscpSubscriber != null)
        {
            iscpSubscriber.TargetComponent = this.transform;
        }
        if (intdashPlayback != null)
        {
            intdashPlayback.TargetComponent = this.transform;
        }
    }
}
