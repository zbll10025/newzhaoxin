using System;
using UnityEngine;

public enum TimerState
{
    NOTWORKER,//空闲
    WORKERING,//工作
    DONE//工作完成
}
public class GameTimer
{
    private float startTime;//计时时长
    private Action task;//计时结束后执行的任务
    private bool isStopTimer;//是否停止当前计时器
    private TimerState state;//当前计时器状态
    public GameTimer()
    {
        ResetTimer();
    }
    //开始计时
    public void StartTimer(float time, Action task)
    {
        startTime = time;
        this.task = task;
        isStopTimer = false;
        state = TimerState.WORKERING;
    }
    //更新计时器
    public void UpdataTimer()
    {
        if (isStopTimer) return;
        startTime -= Time.deltaTime;
        if (startTime < 0f)
        {
            task?.Invoke();
            state = TimerState.DONE;
            isStopTimer = true;
        }
    }
    //确定计时器状态
    public TimerState GetTimerState() => state;
    //重置计时器
    public void ResetTimer()
    {
        startTime = 0;
        task = null;
        isStopTimer = false;
        state = TimerState.NOTWORKER;
    }
}
