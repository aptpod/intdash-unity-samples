using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

public class Dispatcher : MonoBehaviour
{
    public static void RunAsync(Action action)
    {
        ThreadPool.QueueUserWorkItem(o => action());
    }

    public static void RunAsync(Action<object> action, object state)
    {
        ThreadPool.QueueUserWorkItem(o => action(o), state);
    }

    public static void RunOnMainThread(Action action)
    {
        lock (queueLock)
        {
            backlog.Add(action);
            queued = true;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (instance == null)
        {
            instance = new GameObject("Dispatcher").AddComponent<Dispatcher>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }

    private void Update()
    {
        if (queued)
        {
            lock (queueLock)
            {
                var tmp = actions;
                actions = backlog;
                backlog = tmp;
                queued = false;
            }

            foreach (var action in actions)
                action();

            actions.Clear();
        }
    }

    static Dispatcher instance;
    static volatile bool queued = false;
    static object queueLock = new object();
    static List<Action> backlog = new List<Action>();
    static List<Action> actions = new List<Action>();
}