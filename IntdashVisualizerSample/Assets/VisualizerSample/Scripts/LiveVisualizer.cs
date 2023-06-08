using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LiveVisualizer : MonoBehaviour
{
    public string CurrentTimeStringFormat = "HH:mm:ss.fff";
    public TMP_Text CurrentTimeText;

    // Update is called once per frame
    void Update()
    {
        CurrentTimeText.text = DateTime.Now.ToString(CurrentTimeStringFormat);
    }

    private void OnEnable() { }

    private void OnDisable() { }
}
