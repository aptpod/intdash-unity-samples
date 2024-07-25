using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

using Pb;
using intdash.Client;
using intdash.Api;

public class IntdashPlaybackManagerSample : MonoBehaviour
{
    public static IntdashPlaybackManagerSample Shared { private set; get; }

    [SerializeField] private IntdashApiManager apiManager;
    public IntdashApiManager ApiManager => apiManager;

    [Header("Specification of seconds")]
    public int RequestBulkDataDuration = 30 * 60;
    private int _RequestBulkDataDuration;
    private long RequestBulkDataDurationTicks;

    public int RequestPartialDataDuration = 8;
    private int _RequestPartialDataDuration;
    private long RequestPartialDataDurationTicks;

    public int PreReadingTimeAtSeek = 2;
    private int _PreReadingTimeAtSeek;
    private long PreReadingTimeAtSeekTicks;

    public float PlaybackSpeed = 1.0f;

    public int MaxCacheSeconds => RequestPartialDataDuration * 2;

    public static IntdashPlaybackManagerSample GetOrCreateSharedInstance()
    {
        if (Shared != null)
            return Shared;
        var instance = FindObjectOfType<IntdashPlaybackManagerSample>();
        if (instance != null)
            return instance;
        var obj = new GameObject(nameof(IntdashPlaybackManagerSample));
        var script = obj.AddComponent<IntdashPlaybackManagerSample>();
        return script;
    }

    private void Awake()
    {
        if (Shared != null)
        {
            Destroy(this);
            return;
        }
        Debug.Log($"Awake - IntdashPlaybackManager");
        Shared = this;

        if (apiManager == null)
        {
            apiManager = IntdashApiManager.GetOrCreateSharedInstance();
        }

        ClearRequestId();
    }

    private void OnDestroy()
    {
        Debug.Log($"OnDestroy - IntdashPlaybackManager");
        if (Shared == this)
            Shared = null;
        ClearRequestId();
    }

    [Serializable]
    public enum PlaybackStatus
    {
        Play,
        Loading,
        Pause,
        Stop,
    }
    [SerializeField]
    private PlaybackStatus _Status = PlaybackStatus.Stop;
    public PlaybackStatus Status
    {
        private set => _Status = value;
        get => _Status;
    }

    public delegate void ValueChangedPlaybackStatusListener(PlaybackStatus status);
    public event ValueChangedPlaybackStatusListener OnValueChangedPlaybackStatus;
    private void InvokeValueChangedPlaybackStatusEvent(PlaybackStatus status)
    {
        Debug.Log($"OnValueChangedPlaybackStatus(status: {status}) - IntdashPlaybackManager");
        Status = status;
        Dispatcher.RunOnMainThread(() =>
        {
            OnValueChangedPlaybackStatus?.Invoke(Status);
        });
    }

    public delegate void SeekedListener(float value, long time, bool dataUpdated);
    public event SeekedListener OnSeeked;
    private void InvokeSeekedEvent(float value, long time)
    {
        Debug.Log($"OnSeeked(value: {value}, time: {time}) - IntdashPlaybackManager");
        ElapsedTime = Duration * value;
        bool dataUpdated = false;
        if (!(partialDataRequestedTimeForSeek - (RequestPartialDataDurationTicks + PreReadingTimeAtSeekTicks) <= time && time <= partialDataRequestedTimeForSeek))
        {
            dataUpdated = true;
            partialDataRequestedTime = time - PreReadingTimeAtSeekTicks;
            if (partialDataRequestedTime < 0) partialDataRequestedTime = 0;
        }
        CancelPertialRequest();
        Dispatcher.RunOnMainThread(() =>
        {
            OnSeeked?.Invoke(value, time, dataUpdated);
        });
    }

    public bool IsSeeking { set; get; } = false;

    /// <param name="value">Input range is 0~1.0</param>
    public void Seek(float value)
    {
        var time = Duration * value;
        InvokeSeekedEvent(value, StartTimeTicks + time.SecondsToTicks());
    }

    public delegate void SetPlaybackTimeListener(long start, long end);
    public event SetPlaybackTimeListener OnSetPlaybackTime;
    private void InvokeSetPlaybackTimeEvent(long start, long end)
    {
        Debug.Log($"OnSetPlaybackTime(start: {start}, end: {end}) - IntdashPlaybackManager");
        OnSetPlaybackTime?.Invoke(start, end);
    }

    private DateTime baseTime;
    public DateTime? StartTime { private set; get; }
    public DateTime? EndTime { private set; get; }
    public long StartTimeTicks { private set; get; } = 0;
    public long EndTimeTicks { private set; get; } = 0;
    public float ElapsedTime { private set; get; } = 0;
    public float Duration { private set; get; } = 0;
    public float Progress => ElapsedTime / Duration;
    public DateTime CurrentTime => (StartTime ?? DateTime.Now).AddSeconds(ElapsedTime);
    public long CurrentTimeTicks => StartTimeTicks + ElapsedTime.SecondsToTicks();

    public string LocalDataPath = "";

    public bool IsRepeat = true;

    // Start is called before the first frame update
    void Start()
    {
        CheckParameters();
    }

    // Update is called once per frame
    void Update()
    {
        if (Duration <= 0) return;

        CheckParameters();

        if (!isPartialRequesting)
        {
            CheckRequestPartialData();
        }

        // If the time being requested exceeds the current time, it will be put into loading status.
        if (CurrentTimeTicks > partialDataRequestedTime)
        {
            if (Status == PlaybackStatus.Play)
            {
                InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Loading);
            }
        }
        else if (Status == PlaybackStatus.Loading && LoadRequestQueueCount() == 0)
        {
            if (CurrentTimeTicks <= partialDataRequestedTime)
            {
                InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Play);
            }
        }

        if (!(Status == PlaybackStatus.Play && !IsSeeking)) return;

        ElapsedTime += Time.deltaTime * PlaybackSpeed;

        if (ElapsedTime >= Duration)
        {
            if (IsRepeat)
            {
                InvokeSeekedEvent(0, StartTimeTicks);
            }
            else
            {
                Stop();
            }
        }
    }

    private void CheckRequestPartialData()
    {
        // The next request is made when the last request time minus the request request request time is greater than the current time.
        if (!(CurrentTimeTicks > partialDataRequestedTime - RequestPartialDataDurationTicks / 2)) return;
        this.partialRequestId = Guid.NewGuid();
        RequestPartialData(partialDataList, true, this.partialRequestId, partialDataRequestedTime, EndTimeTicks, this.partialRequestCancellationTokenSource.Token);
    }

    private void CheckParameters()
    {
        if (_RequestBulkDataDuration != RequestBulkDataDuration)
        {
            _RequestBulkDataDuration = RequestBulkDataDuration;
            RequestBulkDataDurationTicks = TimeSpan.FromSeconds(RequestBulkDataDuration).Ticks;
        }
        if (_RequestPartialDataDuration != RequestPartialDataDuration)
        {
            _RequestPartialDataDuration = RequestPartialDataDuration;
            RequestPartialDataDurationTicks = TimeSpan.FromSeconds(RequestPartialDataDuration).Ticks;
        }
        if (_PreReadingTimeAtSeek != PreReadingTimeAtSeek)
        {
            _PreReadingTimeAtSeek = PreReadingTimeAtSeek;
            PreReadingTimeAtSeekTicks = TimeSpan.FromSeconds(PreReadingTimeAtSeek).Ticks;
        }
    }

    public bool SetPlaybackTime(DateTime startTime, DateTime endTime)
    {
        var duration = (float)(endTime.Ticks - startTime.Ticks).TicksToSeconds();
        if (duration <= 0)
        {
            Debug.LogError($"Set playback time error. duration: {duration}");
            return false;
        }
        this.baseTime = startTime.ToUniversalTime();
        this.StartTime = startTime.ToLocalTime();
        this.EndTime = endTime.ToLocalTime();
        this.StartTimeTicks = startTime.ToUniversalTime().Ticks;
        if (StartTimeTicks <= 0)
        {
            Debug.LogError($"Set playback time error. StartTimeTicks: {StartTimeTicks}");
            return false;
        }
        this.EndTimeTicks = endTime.ToUniversalTime().Ticks;
        this.Duration = duration;
        this.ElapsedTime = 0;
        this.partialDataRequestedTime = this.StartTimeTicks;
        this.partialDataRequestedTimeForSeek = 0;
        this.Status = PlaybackStatus.Stop;
        this.isRequested = false;
        InvokeSetPlaybackTimeEvent(StartTimeTicks, EndTimeTicks);
        return true;
    }

    #region Requests

    private class PlaybackData
    {
        public readonly Guid Key;
        public readonly string NodeId;
        public readonly string Filter;
        public Action<DataResponseProto[]> Callback;

        public PlaybackData(string nodeId, string filter, Action<DataResponseProto[]> callback)
        {
            this.Key = Guid.NewGuid();
            this.NodeId = nodeId;
            this.Filter = filter;
            this.Callback = callback;
        }
    }
    private Dictionary<Guid, PlaybackData> bulkPlaybacks = new Dictionary<Guid, PlaybackData>();
    private Dictionary<Guid, PlaybackData> partialPlaybacks = new Dictionary<Guid, PlaybackData>();

    #region Register

    public Guid RegisterBulkPlaybackData(string nodeId, string filter, Action<DataResponseProto[]> completion)
    {
        Debug.Log($"RegisterPlaybackBulkData(nodeId: {nodeId}, filter: {filter})");
        var request = new PlaybackData(nodeId, filter, completion);
        bulkPlaybacks.Add(request.Key, request);
        return request.Key;
    }

    public void UnregisterBulkPlaybackData(Guid key)
    {
        bulkPlaybacks.Remove(key);
    }

    public Guid RegisterPartialPlaybackData(string nodeId, string filter, Action<DataResponseProto[]> completion)
    {
        Debug.Log($"RegisterPartialPlaybackData(nodeId: {nodeId}, filter: {filter})");
        var request = new PlaybackData(nodeId, filter, completion);
        partialPlaybacks.Add(request.Key, request);
        return request.Key;
    }

    public void UnregisterPartialPlaybackData(Guid key)
    {
        partialPlaybacks.Remove(key);
    }

    #endregion


    private bool isRequested = false;

    private Guid bulkRequestId = Guid.Empty;
    private Guid partialRequestId = Guid.Empty;
    private CancellationTokenSource bulkRequestCancellationTokenSource;
    private CancellationTokenSource partialRequestCancellationTokenSource;

    private void ClearRequestId()
    {
        bulkRequestId = Guid.Empty;
        partialRequestId = Guid.Empty;
        this.bulkRequestCancellationTokenSource?.Cancel();
        this.partialRequestCancellationTokenSource?.Cancel();
        var cancellationTokenSource = new CancellationTokenSource();
        this.bulkRequestCancellationTokenSource = cancellationTokenSource;
        this.partialRequestCancellationTokenSource = cancellationTokenSource;
    }

    private void CancelPertialRequest()
    {
        this.isPartialRequesting = false;
        partialRequestId = Guid.Empty;
        this.partialRequestCancellationTokenSource?.Cancel();
        var cancellationTokenSource = new CancellationTokenSource();
        this.partialRequestCancellationTokenSource = cancellationTokenSource;
    }

    [SerializeField]
    private long partialDataRequestedTime = 0;
    [SerializeField]
    private long partialDataRequestedTimeForSeek = 0;
    [SerializeField]
    private bool isPartialRequesting = false;
    private Dictionary<string, List<Filter>> partialDataList = new Dictionary<string, List<Filter>>();

    private class Filter
    {
        public readonly string Content;
        public readonly List<Action<DataResponseProto[]>> Callbacks = new List<Action<DataResponseProto[]>>();

        public Filter(string content, Action<DataResponseProto[]> callback)
        {
            Content = content;
            Callbacks.Add(callback);
        }
    }

    private Dictionary<string, List<Filter>> GenerateRequestData(Dictionary<Guid, PlaybackData> playbacks)
    {
        // Creation of data to request (per node).
        var dataList = new Dictionary<string, List<Filter>>();
        foreach (var d in playbacks.Values)
        {
            if (!dataList.ContainsKey(d.NodeId))
            {
                dataList.Add(d.NodeId, new List<Filter> { new Filter(d.Filter, d.Callback) });
            }
            else
            {
                bool found = false;
                foreach (var f in dataList[d.NodeId])
                {
                    if (d.Filter == f.Content)
                    {
                        found = true;
                        f.Callbacks.Add(d.Callback);
                        break;
                    }
                };
                if (!found)
                {
                    dataList[d.NodeId].Add(new Filter(d.Filter, d.Callback));
                }
            }
        }
        return dataList;
    }

    private void StartRequestFirstData()
    {
        Debug.Log($"StartRequestFirstData(bulkPlaybacks.Count: {bulkPlaybacks.Count}, partialPlaybacks.Count: {partialPlaybacks.Count})");
        if (bulkPlaybacks.Count == 0 && partialPlaybacks.Count == 0)
        {
            Debug.Log("bulkPlaybacks & partialPlaybacks is Empty.");
            InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Play);
            return;
        }
        // RequestData
        var bulkReqId = Guid.NewGuid();
        this.bulkRequestId = bulkReqId;
        var partialReqId = Guid.NewGuid();
        this.partialRequestId = partialReqId;
        var bulkCancellationTokenSource = new CancellationTokenSource();
        this.bulkRequestCancellationTokenSource = bulkCancellationTokenSource;
        var partialCancellationTokenSource = new CancellationTokenSource();
        this.partialRequestCancellationTokenSource = partialCancellationTokenSource;
        var requestCnt = 0;
        if (bulkPlaybacks.Count > 0) requestCnt += 1;
        if (partialPlaybacks.Count > 0) requestCnt += 1;

        var firstRequestCompletion = new Action(() =>
        {
            if (bulkReqId != this.bulkRequestId) return;
            requestCnt -= 1;
            if (requestCnt <= 0)
            {
                Debug.Log("End - StartRequestFirstData()");
                InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Play);
            }
        });

        CheckParameters();

        // Bulk
        if (bulkPlaybacks.Count > 0)
        {
            var dataList = GenerateRequestData(bulkPlaybacks);
            RequestBulkData(dataList, true, bulkReqId, StartTimeTicks, EndTimeTicks, bulkCancellationTokenSource.Token, firstRequestCompletion);
        }

        // Partial
        if (partialPlaybacks.Count > 0)
        {
            partialDataList = GenerateRequestData(partialPlaybacks);
            RequestPartialData(partialDataList, true, partialReqId, StartTimeTicks, EndTimeTicks, partialCancellationTokenSource.Token, firstRequestCompletion);
        }
    }

    private void RequestBulkData(Dictionary<string, List<Filter>> dataList, bool isFirst, Guid reqId, long time, long endTime, CancellationToken cancellationToken, Action firstRequestCompletion = null)
    {
        // Quit request if playback is stopped.
        if (Status == PlaybackStatus.Stop) return;

        if (time >= endTime || reqId != this.bulkRequestId)
        {
            if (!isFirst) Debug.Log($"RequestBulkData completed.");
            return;
        }
        var duration = RequestBulkDataDurationTicks;
        Debug.Log($"RequestBulkDataDurationTicks: {duration}, endTime - time: {endTime - time}, = {endTime - time < duration}, {duration.TicksToTotalSeconds()}");
        if (endTime - time < duration)
        {
            duration = endTime - time;
        }

        var start = new DateTime(time, DateTimeKind.Utc);
        var end = new DateTime(time + duration, DateTimeKind.Utc);
        Debug.Log($"RequestBulkData(time: {start.ToString("yyyy/MM/dd HH:mm:ss.ffffff")}, duration: {duration.TicksToSeconds()}, requestId: {reqId}, isFirst: {isFirst})");

        var requestCnt = 0;
        foreach (var kv in dataList)
            foreach (var f in kv.Value)
                requestCnt += 1;

        // Execute all requests in parallel and aggregate them into this callback.
        var completion = new Action(() =>
        {
            requestCnt -= 1;
            if (requestCnt <= 0)
            {
                if (reqId != this.bulkRequestId) return;

                // First request completed.
                if (isFirst)
                {
                    firstRequestCompletion?.Invoke();
                }

                // Make a request for the next period.
                RequestBulkData(dataList, false, reqId, time + duration, endTime, cancellationToken);
            }
        });

        Task.Run(async () =>
        {
            foreach (var kv in dataList)
            {
                foreach (var f in kv.Value)
                {
                    try
                    {
                        DataResponseProto[] dataPoints;
                        dataPoints = await RequestListDataPoints(kv.Key, new List<string> { f.Content }, start, end, cancellationToken: cancellationToken);
                        if (reqId != this.bulkRequestId) return;
                        foreach (var c in f.Callbacks) c.Invoke(dataPoints);
                        completion.Invoke();
                    }
                    catch (OperationCanceledException)
                    {
                        Debug.LogWarning($"RequestBulkData canceled , start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, requestId: {reqId}");
                    }
                    catch (Exception e)
                    {
                        if (reqId != bulkRequestId)
                        {
                            // Canceled
                            Debug.LogWarning($"RequestBulkData canceled , start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, requestId: {reqId}");
                            return;
                        }
                        Debug.LogError($"RequestBulkData error. {e.Message}, start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, requestId: {reqId}");
                        completion.Invoke();
                    }
                }
            }
        });
    }

    private void RequestPartialData(Dictionary<string, List<Filter>> dataList, bool isFirst, Guid reqId, long time, long endTime, CancellationToken cancellationToken, Action firstRequestCompletion = null)
    {
        // Quit request if playback is stopped
        if (Status == PlaybackStatus.Stop) return;
        if (isPartialRequesting) return;
        if (reqId != partialRequestId) return;

        if (time >= endTime)
        {
            if (!isFirst) Debug.Log($"RequestPartialData completed.");
            return;
        }

        isPartialRequesting = true;

        var duration = (CurrentTimeTicks + RequestPartialDataDurationTicks) - time;
        if (endTime - time < duration)
        {
            duration = endTime - time;
        }

        var start = new DateTime(time, DateTimeKind.Utc);
        var end = new DateTime(time + duration, DateTimeKind.Utc);
        Debug.Log($"RequestPartialData(time: {start.ToString("yyyy/MM/dd HH:mm:ss.ffffff")}, duration: {duration.TicksToSeconds()}, requestId: {reqId}, isFirst: {isFirst})");

        var requestCnt = 0;
        foreach (var kv in dataList)
            foreach (var f in kv.Value)
                requestCnt += 1;

        // Execute all requests in parallel and aggregate them into this callback.
        var completion = new Action(() =>
        {
            requestCnt -= 1;
            if (requestCnt <= 0)
            {
                if (reqId != this.partialRequestId) return;

                this.partialDataRequestedTime = time + duration;
                this.partialDataRequestedTimeForSeek = time + duration;
                this.isPartialRequesting = false;

                // First request completed.
                if (isFirst)
                {
                    firstRequestCompletion?.Invoke();
                }
            }
        });

        Task.Run(async () =>
        {
            foreach (var kv in dataList)
            {
                foreach (var f in kv.Value)
                {
                    try
                    {
                        DataResponseProto[] dataPoints;
                        dataPoints = await RequestListDataPoints(kv.Key, new List<string> { f.Content }, start, end, cancellationToken: cancellationToken);
                        if (reqId != this.partialRequestId) return;
                        foreach (var c in f.Callbacks) c.Invoke(dataPoints);
                        completion.Invoke();
                    }
                    catch (OperationCanceledException)
                    {
                        Debug.LogWarning($"RequestPartialData canceled , start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, requestId: {reqId}");
                    }
                    catch (Exception e)
                    {
                        if (reqId != partialRequestId)
                        {
                            // Canceled
                            Debug.LogWarning($"RequestPartialData canceled , start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, requestId: {reqId}");
                            return;
                        }
                        Debug.LogError($"RequestPartialData error. {e.Message}, start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ,")}, requestId: {reqId}");
                        completion.Invoke();
                    }
                }
            }
        });

        if (requestCnt == 0)
        {
            Debug.Log($"Not found partia requests. start: {start.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, end: {end.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ")}, requestId: {reqId}, isFirst: {isFirst}");
            completion.Invoke();
        }
    }

    private async Task<DataResponseProto[]> RequestListDataPoints(string name, List<string> filters, DateTime start, DateTime end, long? limit = null, string order = null, CancellationToken cancellationToken = default)
    {
        if (ApiManager == null)
        {
            throw new Exception("Not found APIManager.");
        }
        var sStart = default(string);
        if (start != null)
        {
            sStart = start.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ");
        }
        var sEnd = default(string);
        if (end != null)
        {
            sEnd = end.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFZ");
        }
        // Accesses the MeasDataPointsApi.ListDataPointsAPI.
        Debug.Log($"RequestListDataPoints(name: {name}, start: {sStart}, end: {sEnd}, filter: [{string.Join(",", filters)}], limit: {limit ?? -1}, order: {order ?? "null"})");
        var api = new MeasDataPointsApi(ApiManager.HttpClient, ApiManager.Configuration);
        FileParameter fp;
        if (string.IsNullOrEmpty(ApiManager.ProjectUuid))
        {
            fp = await api.ListDataPointsForProtobufAsync(
                name: name,
                start: sStart,
                end: sEnd,
                idq: filters,
                limit: limit,
                order: order,
                timeFormat: "rfc3339",
                cancellationToken: cancellationToken);
        }
        else
        {
            fp = await api.ListProjectDataPointsForProtobufAsync(
                projectUuid: ApiManager.ProjectUuid,
                name: name,
                start: sStart,
                end: sEnd,
                idq: filters,
                limit: limit,
                order: order,
                timeFormat: "rfc3339",
                cancellationToken: cancellationToken);
        }
        var list = new List<DataResponseProto>();
        int len = 0;
        byte[] payload;
        using (var reader = new BinaryReader(fp.Content, Encoding.UTF8))
        {
            while (fp.Content.Position != fp.Content.Length)
            {
                len = (int)reader.ReadUInt64();
                payload = reader.ReadBytes(len);
                var data = DataResponseProto.Parser.ParseFrom(payload);
                list.Add(data);
            }
        }
        Debug.Log($"OnReceiveRequestListDataPoints {list.Count} points, name: {name}, start: {sStart}, end: {sEnd}, filter: [{string.Join(",", filters)}], limit: {limit ?? -1}, order: {order ?? "null"}");
        return list.ToArray();
    }

    #endregion

    #region Player Controls

    public bool Play()
    {
        if (StartTime == null || EndTime == null) return false;
        if (Status == PlaybackStatus.Play) return false;
        prevStatus = PlaybackStatus.Play;
        if (Status == PlaybackStatus.Loading && LoadRequestQueueCount() > 0) return false;
        if (isRequested)
        {
            InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Play);
        }
        else
        {
            isRequested = true;
            isPartialRequesting = false;
            InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Loading);
            StartRequestFirstData();
        }
        return true;
    }

    public void Pause()
    {
        if (Status == PlaybackStatus.Pause) return;
        prevStatus = PlaybackStatus.Pause;
        if (Status == PlaybackStatus.Loading && LoadRequestQueueCount() > 0) return;
        InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Pause);
    }

    public void Stop()
    {
        if (Status == PlaybackStatus.Stop) return;
        ElapsedTime = 0;
        isRequested = false;
        ClearRequestId();
        prevStatus = PlaybackStatus.Stop;
        ClearLoadRequestQueue();
        InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Stop);
    }

    private PlaybackStatus prevStatus = PlaybackStatus.Play;
    [SerializeField]
    private List<int> loadRequestQueue = new List<int>();
    private object loadRequestLock = new object();
    private int LoadRequestQueueCount()
    {
        lock (loadRequestQueue) return loadRequestQueue.Count;
    }

    private void ClearLoadRequestQueue()
    {
        lock (loadRequestLock) loadRequestQueue.Clear();
    }

    public int LoadRequest()
    {
        var instanceId = GenerateInstanceID();
        lock (loadRequestLock) loadRequestQueue.Add(instanceId);
        InvokeValueChangedPlaybackStatusEvent(PlaybackStatus.Loading);
        return instanceId;
    }

    private static int GenerateInstanceID()
    {
        Guid guid = Guid.NewGuid();
        var bytes = guid.ToByteArray();
        var id = (int)BitConverter.ToInt64(bytes, 0);
        return id;
    }

    public void LoadRequestEnd(int requestId)
    {
        int requestCnt;
        lock (loadRequestLock)
        {
            if (loadRequestQueue.Count <= 0) return;
            if (!loadRequestQueue.Remove(requestId)) return;
            requestCnt = loadRequestQueue.Count;
        }
        if (requestCnt == 0)
        {
            switch (prevStatus)
            {
                case PlaybackStatus.Play: Play(); break;
                case PlaybackStatus.Pause: Pause(); break;
                default: break;
            }
        }

    }

    #endregion
}
