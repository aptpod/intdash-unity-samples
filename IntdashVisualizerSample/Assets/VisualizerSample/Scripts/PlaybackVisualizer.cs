using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class PlaybackVisualizer : MonoBehaviour
{
    public string StartEndTimeStringFormat = "yyyy/M/d H:m:s";
    public string StartTime = "2000/01/01 00:00:00";
    public string EndTime = "2000/01/01 00:01:00";

    public string CurrentTimeStringFormat = "HH:mm:ss.fff";
    public TMP_Text CurrentTimeText;
    public TMP_Text StartEndText;

    [SerializeField]
    private IntdashPlaybackManagerSample playback;

    private DateTime start, end;

    // Start is called before the first frame update
    void Start()
    {
        if (playback == null)
        {
            playback = IntdashPlaybackManagerSample.GetOrCreateSharedInstance();
        }
        if (!(DateTime.TryParseExact(StartTime, StartEndTimeStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out start))
            || !(DateTime.TryParseExact(EndTime, StartEndTimeStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out end)))
        {
            Debug.LogError($"Failed to parse playback time. startInput: {StartTime}, endInput: {EndTime}");
            return;
        }
        StartEndText.text = $"{start.ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss")} - {end.ToLocalTime().ToString("HH:mm:ss")}";
        if (!playback.ApiManager.IsEnableApi)
        {
            playback.ApiManager.OnEnableApi += ApiManager_OnEnableApi;
        }
        else
        {
            playback.SetPlaybackTime(start, end);
            playback.Play();
        }
    }

    private void ApiManager_OnEnableApi(string version)
    {
        Debug.Log($"ApiManager_OnEnableApi() - ConstructionSuiteVisualizerForPlayback");
        playback.SetPlaybackTime(start, end);
        playback.Play();
    }

    private void Update()
    {
        if (playback.Status != IntdashPlaybackManagerSample.PlaybackStatus.Play) return;
        CurrentTimeText.text = playback.CurrentTime.ToString(CurrentTimeStringFormat);
    }

    private void OnEnable()
    {
        if (playback != null)
            if (playback.Duration > 0)
                playback.Play();
    }

    private void OnDisable()
    {
        if (playback != null)
            playback.Pause();
    }
}
