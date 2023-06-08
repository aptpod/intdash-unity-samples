using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionControlSample : MonoBehaviour
{
    public IscpConnection Connection;

    public bool Connect = false;
    private bool? _Connect;

    private void Awake()
    {
        if (Connection == null)
        {
            Connection = IscpConnection.GetOrCreateSharedInstance();
        }
        Connection.ConnectOnStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Connection == null) return;
        if (_Connect != Connect)
        {
            _Connect = Connect;
            if (Connect && !Connection.IsConnecting)
            {
                Connection.Connect();
            } 
            else if(!Connect && Connection.IsConnecting)
            {
                Connection.Close();
            }
        }
    }
}
