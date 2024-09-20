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
    /// 添加事件监听
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="action">事件</param>
    public void AddEventListening<T>(string eventName, Action<T> action)
    {
        if (eventCenter.TryGetValue(eventName, out var e))
        {
            (e as IEventHelp<T>)?.AddCall(action);
        }
        else
        {
            // 如果事件中心不存在该事件名，则添加新的事件
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
            Debug.Log($"当前未找到{eventName}的事件, 无法呼叫");
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
            Debug.Log($"当前未找到{eventName}的事件, 无法删除");
        }
    }

    /// <summary>
    /// 添加不需要额外参数的事件监听
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="action">事件</param>
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