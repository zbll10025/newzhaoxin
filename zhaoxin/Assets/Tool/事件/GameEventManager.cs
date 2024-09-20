using System;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
using zhou.Tool.Singleton;


public class GameEventManager : Singleton<GameEventManager>
{
    private interface IEventHelp<T>
    {
        void AddCall(Action<T> action);
        void Call(T arg);
        void Remove(Action<T> action);
    }

    private class EventHelp<T> : IEventHelp<T>
    {
        public Action<T> Action { get; private set; }

        public EventHelp(Action<T> action)
        {
            Action = action;
        }

        public void AddCall(Action<T> action)
        {
            Action += action;
        }

        public void Call(T arg)
        {
            Action?.Invoke(arg);
        }

        public void Remove(Action<T> action)
        {
            Action -= action;
        }
    }

    private Dictionary<string, object> eventCenter = new Dictionary<string, object>();

    /// <summary>
    /// ����¼�����
    /// </summary>
    /// <param name="eventName">�¼�����</param>
    /// <param name="action">�¼�</param>
    public void AddEventListening<T>(string eventName, Action<T> action)
    {
        if (eventCenter.TryGetValue(eventName, out var e))
        {
            (e as IEventHelp<T>)?.AddCall(action);
        }
        else
        {
            // ����¼����Ĳ����ڸ��¼�����������µ��¼�
            eventCenter.Add(eventName, new EventHelp<T>(action));
        }
    }

    public void CallEvent<T>(string eventName, T arg)
    {
        if (eventCenter.TryGetValue(eventName, out var e))
        {
            (e as IEventHelp<T>)?.Call(arg);
        }
        else
        {
            Debug.Log($"��ǰδ�ҵ�{eventName}���¼�, �޷�����");
        }
    }

    public void RemoveEvent<T>(string eventName, Action<T> action)
    {
        if (eventCenter.TryGetValue(eventName, out var e))
        {
            (e as IEventHelp<T>)?.Remove(action);
        }
        else
        {
            Debug.Log($"��ǰδ�ҵ�{eventName}���¼�, �޷�ɾ��");
        }
    }

    /// <summary>
    /// ��Ӳ���Ҫ����������¼�����
    /// </summary>
    /// <param name="eventName">�¼�����</param>
    /// <param name="action">�¼�</param>
    public void AddEventListening(string eventName, Action action)
    {
        AddEventListening<object>(eventName, _ => action());
    }

    public void CallEvent(string eventName)
    {
        CallEvent<object>(eventName, null);
    }

    public void RemoveEvent(string eventName, Action action)
    {
        RemoveEvent<object>(eventName, _ => action());
    }
}