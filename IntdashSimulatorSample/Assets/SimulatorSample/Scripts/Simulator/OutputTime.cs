using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputTime : MonoBehaviour
{
    public TMP_Text OutputText;
    public string StartTimeStringFormat = "yyyy/MM/dd HH:mm:ss";
    public string CurrentTimeStringFormat = "HH:mm:ss.ffffff";

    [SerializeField]
    private string startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now.ToString(StartTimeStringFormat);
    }

    // Update is called once per frame
    void Update()
    {
        OutputText.text = $"{startTime} -\n {DateTime.Now.ToString(CurrentTimeStringFormat)}";
    }
}
