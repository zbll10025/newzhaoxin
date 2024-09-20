using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    public IState currentState;
    /// <summary>
    /// 切换状态的接口API
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(IState newState)
    {

        //可能为空用
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
    /// <summary>
    /// 处理输入的接口API
    /// </summary>
    public void HandInput()
    {
        //只允许一个状态在这里更新
        currentState?.HandInput();
    }
    /// <summary>
    /// 更新非物理逻辑的接口API
    /// </summary>
    public void Update()
    {
        currentState?.Update();
    }
    public void AnimationFinishTrigger()
    {
        currentState?.AnimationFinishTrigger();
    }
}
