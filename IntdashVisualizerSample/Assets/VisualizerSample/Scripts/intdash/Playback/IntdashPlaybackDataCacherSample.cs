using System;
using System.Collections.Generic;

public class IntdashPlaybackDataCacherSample
{
    public class DataPoint
    {
        public object Value;
        public int Index;
        public Dictionary<string, object> Options;

        public DataPoint(int index, object value, Dictionary<string, object> options)
        {
            this.Index = index;
            this.Value = value;
            this.Options = options ?? new Dictionary<string, object>();
        }
    }

    public class CacheData
    {
        public readonly long ElapsedSeconds;
        public readonly bool IsSingleDataMode;

        private List<long> timeList = new List<long>();
        private List<List<DataPoint>> dataList = new List<List<DataPoint>>();
        private object lockObj = new object();

        public CacheData(long elapsedSeconds, bool singleDataMode)
        {
            ElapsedSeconds = elapsedSeconds;
            IsSingleDataMode = singleDataMode;
        }

        public long Count => dataList.Count;

        public int Index = 0;

        public void Add(int index, object value, long time, Dictionary<string, object> options)
        {
            lock (lockObj)
            {
                var point = new DataPoint(index, value, options);
                if (timeList.Contains(time))
                {
                    var i = timeList.IndexOf(time);
                    if (IsSingleDataMode)
                        dataList[i][0] = point;
                    else
                        dataList[i].Add(point);
                }
                else
                {
                    var data = new List<DataPoint>() { point };

                    var isInsert = false;
                    for (var i = 0; i < timeList.Count; i++)
                    {
                        var t = timeList[i];
                        if (time < t)
                        {
                            timeList.Insert(i, time);
                            dataList.Insert(i, data);
                            isInsert = true;
                            break;
                        }
                    }
                    if (!isInsert)
                    {
                        timeList.Add(time);
                        dataList.Add(data);
                    }
                }
            }
        }

        public KeyValuePair<long, DataPoint[]> this[int index]
        {
            get
            {
                return new KeyValuePair<long, DataPoint[]>(timeList[index], dataList[index].ToArray());
            }
        }

        public void Clear()
        {
            lock (lockObj)
            {
                timeList.Clear();
                dataList.Clear();
            }
        }

        ~CacheData()
        {
            //Debug.Log($"Dispose CacheData({ElapsedSeconds})");
            Clear();
        }
    }

    private List<long> timeList = new List<long>();
    private List<CacheData> dataList = new List<CacheData>();
    private object lockObj = new object();

    public long BaseTime = -1;
    public int Index { private set; get; } = 0;
    public long PrevRequestTime { private set; get; } = 0;
    /// <summary>
    /// Maximum cache seconds.
    /// Only retained for the specified period of time.
    /// If less than 0, all data is cached.
    /// When new data is added, a confirmation process is performed and the old data is deleted.
    /// </summary>
    public int MaxCacheSeconds = 0;
    private List<long> cacheSeconds = new List<long>();

    public void ResetReadPostion()
    {
        lock (lockObj)
        {
            Index = 0;
            PrevRequestTime = 0;
            if (dataList.Count > 0)
            {
                dataList[0].Index = 0;
            }
        }
    }
    public void SeekTo(long time)
    {
        if (BaseTime < 0)
            return;
        var elapsedSeconds = (time - BaseTime) / (10 * 1000 * 1000);
        if (elapsedSeconds < 0)
        {
            elapsedSeconds = 0;
        }

        lock (lockObj)
        {
            int index = 0;
            if (timeList.Contains(elapsedSeconds))
            {
                index = timeList.IndexOf(elapsedSeconds);
            }
            else
            {
                for (int i = 0; i < timeList.Count; i++)
                {
                    if (timeList[i] <= elapsedSeconds)
                        index = i;
                    else
                        break;
                }
            }

            Index = index;
            PrevRequestTime = time;
            if (index < dataList.Count)
            {
                dataList[index].Index = 0;
            }
        }
    }

    public void Clear()
    {
        lock (lockObj)
        {
            Index = 0;
            PrevRequestTime = 0;
            BaseTime = -1;
            timeList.Clear();
            dataList.Clear();
            cacheSeconds.Clear();
        }
    }

    public readonly bool IsSigleDataMode = false;

    public IntdashPlaybackDataCacherSample(bool singleDataMode = false)
    {
        IsSigleDataMode = singleDataMode;
    }

    ~IntdashPlaybackDataCacherSample()
    {
        Clear();
    }

    public bool Contains(long time)
    {
        if (BaseTime < 0)
            return false;
        var diff = time - BaseTime;
        if (diff < 0) diff = 0;
        var elapsedSeconds = diff.TicksToTotalSeconds();
        //Debug.Log($"ElapsedSecond: {elapsedSeconds}, time: {time}");

        bool result;
        lock (lockObj)
        {
            result = timeList.Contains(elapsedSeconds);
        }
        return result;
    }

    public void Add(object value, long time, Dictionary<string, object> options = null, int index = 0)
    {
        lock (lockObj)
        {
            if (BaseTime < 0)
                BaseTime = time;
            var elapsedSeconds = (time - BaseTime).TicksToTotalSeconds();
            //Debug.Log($"ElapsedSecond: {elapsedSeconds}, time: {time}");

            if (timeList.Contains(elapsedSeconds))
            {
                var i = timeList.IndexOf(elapsedSeconds);
                dataList[i].Add(index, value, time, options);
            }
            else
            {
                var data = new CacheData(elapsedSeconds, IsSigleDataMode);
                data.Add(index, value, time, options);

                var isInsert = false;
                for (var i = 0; i < timeList.Count; i++)
                {
                    var t = timeList[i];
                    if (elapsedSeconds < t)
                    {
                        timeList.Insert(i, elapsedSeconds);
                        dataList.Insert(i, data);
                        break;
                    }
                }
                if (!isInsert)
                {
                    timeList.Add(elapsedSeconds);
                    dataList.Add(data);
                }
            }

            if (MaxCacheSeconds > 0)
            {
                if (!cacheSeconds.Contains(elapsedSeconds))
                {
                    cacheSeconds.Add(elapsedSeconds);
                }
                else
                {
                    cacheSeconds.Remove(elapsedSeconds);
                    cacheSeconds.Add(elapsedSeconds);
                }
                var cnt = cacheSeconds.Count - MaxCacheSeconds;
                if (cnt > 0)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        var t = cacheSeconds[i];
                        var ci = timeList.IndexOf(t);
                        if (ci >= 0)
                        {
                            //Debug.Log($"Remove cache. {timeList[index]} - VDataCacher");
                            timeList.RemoveAt(ci);
                            dataList.RemoveAt(ci);
                            if (ci <= this.Index && this.Index > 0)
                            {
                                this.Index -= 1;
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Delete data prior to the specified period.
    /// </summary>
    public void RemoveBefore(long time)
    {
        lock (lockObj)
        {
            if (BaseTime < 0)
                return;
            var diff = time - BaseTime;
            if (diff < 0) diff = 0;
            var elapsedSeconds = diff.TicksToTotalSeconds();
            //Debug.Log($"ElapsedSecond: {elapsedSeconds}, time: {time}");

            var removeCnt = 0;
            for (int i = 0; i < timeList.Count; i++)
            {
                var t = timeList[i];
                if (t >= elapsedSeconds) break;
                removeCnt++;
            }
            for (int i = 0; i < removeCnt; i++)
            {
                timeList.RemoveAt(0);
                dataList.RemoveAt(0);
            }
            this.Index -= removeCnt;
            if (Index < 0)
            {
                Index = 0;
            }

            cacheSeconds.Remove(elapsedSeconds);
        }
    }

    /// <summary>
    /// Delete data after the specified period.
    /// </summary>
    public void RemoveAfter(long time)
    {
        lock (lockObj)
        {
            if (BaseTime < 0)
                return;
            var diff = time - BaseTime;
            if (diff < 0) diff = 0;
            var elapsedSeconds = diff.TicksToTotalSeconds();
            //Debug.Log($"ElapsedSecond: {elapsedSeconds}, time: {time}");

            var removeCnt = 0;
            for (int i = timeList.Count - 1; i >= 0; i--)
            {
                var t = timeList[i];
                if (t <= elapsedSeconds) break;
                removeCnt++;
            }
            long prevT = 0;
            if (Index < timeList.Count)
            {
                prevT = timeList[Index];
            }
            var index = Index -= removeCnt;
            if (index < 0) index = 0;
            for (int i = 0; i < removeCnt; i++)
            {
                timeList.RemoveAt(timeList.Count - 1);
                dataList.RemoveAt(dataList.Count - 1);
            }
            for (int i = index; i < removeCnt && i < timeList.Count; i++)
            {
                if (prevT <= timeList[i])
                {
                    index = i;
                }
                else
                {
                    break;
                }
            }
            Index = index;

            cacheSeconds.Remove(elapsedSeconds);
        }
    }

    public void Remove(long elapsedSeconds)
    {
        lock (lockObj)
        {
            var index = timeList.IndexOf(elapsedSeconds);
            //Debug.log($"Remove elapsedSeconds: {elapsedSeconds}, index: {index}, Index: {Index}");
            if (index >= 0)
            {
                timeList.RemoveAt(index);
                dataList.RemoveAt(index);

                if (MaxCacheSeconds > 0)
                {
                    cacheSeconds.Remove(elapsedSeconds);
                }

                if (index <= this.Index && this.Index > 0)
                {
                    this.Index -= 1;
                }
            }
        }
    }

    public CacheData this[int index]
    {
        get
        {
            return dataList[index];
        }
    }

    public long Count => dataList.Count;

    /// <summary>
    /// Requests data less than the specified time from the current seek position (index).
    /// </summary>
    /// <param name="time">Time to be acquired</param>
    /// <param name="completion">If data is found, it will be called (*It can happen multiple times, not just once).</param>
    public void RequestData(long time, Action<int, object, long, Dictionary<string, object>> completion)
    {
        this.PrevRequestTime = time;
        lock (lockObj)
        {
            //Debug.Log($"RequestData time: {new DateTime(time).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff")}, index: {Index}, count: {Count} - VDataCacher");
            for (var i = this.Index; i < this.Count; i++)
            {
                var cache = this[i];
                if (this.Index != i)
                {
                    this.Index = i;
                    cache.Index = 0;
                }
                //Debug.Log($"[{i}] cache index: {cache.Index}, count: {cache.Count}");
                for (var j = cache.Index; j < cache.Count; j++)
                {
                    var kv = cache[j];
                    //Debug.Log($"[{i}] cache[{j}] time: {kv.Key} VS {time}, Diff: {(time - kv.Key)}");
                    if (kv.Key < time)
                    {
                        cache.Index = j + 1;
                        foreach (var v in kv.Value)
                        {
                            completion?.Invoke(v.Index, v.Value, kv.Key, v.Options);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Requests the last data less than the specified time from the current seek position (index).
    /// </summary>
    /// <param name="time">Time to be acquired</param>
    /// <param name="completion">If data is found, it will be called.</param>
    public void RequestLastData(long time, Action<int, object, long, Dictionary<string, object>> completion)
    {
        this.PrevRequestTime = time;
        long t = 0;
        DataPoint[] points = null;
        bool isBreak = false;
        lock (lockObj)
        {
            //Debug.Log($"RequestLastData time: {new DateTime(time).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff")}, index: {Index}, count: {Count} - VDataCacher");
            for (var i = this.Index; i < this.Count && !isBreak; i++)
            {
                var cache = this[i];
                if (this.Index != i)
                {
                    this.Index = i;
                    cache.Index = 0;
                }
                //Debug.Log($"[{i}] cache index: {cache.Index}, count: {cache.Count}");
                for (var j = cache.Index; j < cache.Count; j++)
                {
                    var kv = cache[j];
                    //Debug.Log($"[{i}] cache[{j}] time: {new DateTime(kv.Key).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff")} VS {new DateTime(time).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff")}, Diff: {(time - kv.Key).TickToTotalSeconds()}");
                    if (kv.Key < time)
                    {
                        cache.Index = j + 1;
                        t = kv.Key;
                        points = kv.Value;
                    }
                    else
                    {
                        isBreak = true;
                        break;
                    }
                }
            }
        }

        if (points != null)
        {
            foreach (var p in points)
            {
                completion?.Invoke(p.Index, p.Value, t, p.Options);
            }
        }
    }

}