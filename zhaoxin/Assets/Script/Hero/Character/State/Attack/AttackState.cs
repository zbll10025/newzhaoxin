using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    public AttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        base.Enter();
        
        TimerManager.MainInstance.GetTimer(0.1f, BusyForAttack);//1.修改移动时攻击时后可以移动的BUG
                                                                //2.但给了点时间模拟惯性可以动一点
    }
    public override void Enter()
    {
        base.Enter();
        triggerCalled = false;
    }
    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
       
        base.Update();
        if (triggerCalled)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public void BusyForAttack()
    {
        ZeroVelocity();
    }
}
