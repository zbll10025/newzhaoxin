using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    public AttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        base.Enter();
        
        TimerManager.MainInstance.GetTimer(0.1f, BusyForAttack);//1.�޸��ƶ�ʱ����ʱ������ƶ���BUG
                                                                //2.�����˵�ʱ��ģ����Կ��Զ�һ��
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
