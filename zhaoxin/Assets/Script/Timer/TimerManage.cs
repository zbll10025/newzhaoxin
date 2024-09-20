using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhou.Tool.Singleton;
using System.Globalization;
using System;

public class TimerManager : Singleton<TimerManager>
{
    [SerializeField] private int initMaxTimerCount;

    private Queue<GameTimer> notWorkerTimer = new Queue<GameTimer>();

    private List<GameTimer> workeringTimer = new List<GameTimer>();

    private void Start()
    {
        InitTimerManager();
    }
    private void Update()
    {
        UpDateWorkeringTimer();
    }
    private void InitTimerManager()
    {
        for (int i = 0; i < initMaxTimerCount; i++)
        {
            GreatTimer();
        }
    }
    private void GreatTimer()
    {
        var timer = new GameTimer();

        notWorkerTimer.Enqueue(timer);
    }
    public GameTimer GetTimer(float time, Action action)
    {
        if (notWorkerTimer.Count == 0)
        {
            GreatTimer();
            var timer = notWorkerTimer.Dequeue();
            timer.StartTimer(time, action);
            workeringTimer.Add(timer);
            return timer;
        }
        else
        {
            var timer = notWorkerTimer.Dequeue();
            timer.StartTimer(time, action);
            workeringTimer.Add(timer);
            return timer;
        }
    }
    public void UnregisterTimer(GameTimer gameTimer)
    {

    }
    private void UpDateWorkeringTimer()
    {
        if (workeringTimer.Count == 0) return;
        for (int i = 0; i < workeringTimer.Count; i++)
        {
            if (workeringTimer[i].GetTimerState() == TimerState.WORKERING)
            {
                workeringTimer[i].UpdataTimer();
            }
            else
            {
                workeringTimer[i].ResetTimer();
                notWorkerTimer.Enqueue(workeringTimer[i]);
                workeringTimer.Remove(workeringTimer[i]);
            }
        }
    }
}
