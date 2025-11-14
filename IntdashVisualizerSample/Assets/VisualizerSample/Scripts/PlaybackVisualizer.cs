using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaybackVisualizer : MonoBehaviour
{
    public string StartEndTimeStringFormat = "yyyy/M/d H:m:s";
    public string StartTime = "2000/01/01 00:00:00";
    public string EndTime = "2000/01/01 00:01:00";

    public string CurrentTimeStringFormat = "HH:mm:ss.fff";
    public TMP_Text CurrentTimeText;
    public TMP_Text StartEndText;
    public TMP_Text LoadingText;
    public Slider SeekSlider;

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
        // SeekBar
        {
            var trigger = SeekSlider.gameObject.GetOrAddComponent<EventTrigger>();
            var pointerDown = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.PointerDown,
            };
            pointerDown.callback.AddListener((e) =>
            {
                Debug.Log($"SeekSlider.OnPointerDown(value: {SeekSlider.value}) - Controller");
                playback.IsSeeking = true;
                playback.Seek(SeekSlider.value);
                var now = playback.CurrentTime;
                if (playback.Status != IntdashPlaybackManagerSample.PlaybackStatus.Loading)
                {
                    CurrentTimeText.text = now.ToString(CurrentTimeStringFormat);
                }
            });
            trigger.triggers.Add(pointerDown);
            var pointerUp = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.PointerUp,
            };
            pointerUp.callback.AddListener((e) =>
            {
                Debug.Log($"SeekSlider.OnPointerUp(value: {SeekSlider.value}) - Controller");
                playback.IsSeeking = false;
            });
            trigger.triggers.Add(pointerUp);
            SeekSlider.onValueChanged.AddListener((e) =>
            {
                if (!playback.IsSeeking) return;
                Debug.Log($"SeekSlider.onValueChanged(value: {SeekSlider.value}) - Controller");
                playback.Seek(SeekSlider.value);
                var now = playback.CurrentTime;
                if (playback.Status != IntdashPlaybackManagerSample.PlaybackStatus.Loading)
                {
                    CurrentTimeText.text = now.ToString(CurrentTimeStringFormat);
                }
            });
        }

        if (!(DateTime.TryParseExact(StartTime, StartEndTimeStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out start))
            || !(DateTime.TryParseExact(EndTime, StartEndTimeStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out end)))
        {
            Debug.LogError($"Failed to parse playback time. startInput: {StartTime}, endInput: {EndTime}");
            return;
        }
        StartEndText.text = $"{start.ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss")} - {end.ToLocalTime().ToString("HH:mm:ss")}";
        LoadingText.gameObject.SetActive(false);

        playback.OnValueChangedPlaybackStatus += PlaybackManager_OnValueChangedPlaybackStatus;
        playback.OnSeeked += PlaybackManager_OnSeeked;

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
        Debug.Log($"ApiManager_OnEnableApi() - PlaybackVisualizer");
        playback.SetPlaybackTime(start, end);
        playback.Play();
    }

    private void PlaybackManager_OnValueChangedPlaybackStatus(IntdashPlaybackManagerSample.PlaybackStatus status)
    {
        Debug.Log($"PlaybackManager_OnValueChangedPlaybackStatus(status: {status}) - PlaybackVisualizer");
        switch (status)
        {
            case IntdashPlaybackManagerSample.PlaybackStatus.Play:
                LoadingText.gameObject.SetActive(false);
                // TODO
                break;
            case IntdashPlaybackManagerSample.PlaybackStatus.Pause:
                LoadingText.gameObject.SetActive(false);
                // TODO
                break;
            case IntdashPlaybackManagerSample.PlaybackStatus.Loading:
                LoadingText.gameObject.SetActive(true);
                // TODO
                break;
            case IntdashPlaybackManagerSample.PlaybackStatus.Stop:
                LoadingText.gameObject.SetActive(false);
                // TODO
                break;
            default: break;
        }
    }

    private void PlaybackManager_OnSeeked(float value, long time, bool dataUpdated)
    {
        // TODO
    }

    private void Update()
    {
        if (playback.Status != IntdashPlaybackManagerSample.PlaybackStatus.Play) return;
        CurrentTimeText.text = playback.CurrentTime.ToString(CurrentTimeStringFormat);
        SeekSlider.value = playback.Progress;
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
