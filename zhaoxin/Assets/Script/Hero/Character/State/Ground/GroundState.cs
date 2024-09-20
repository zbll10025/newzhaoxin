using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundState:PlayerState
{
    public GroundState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        
        if (stateMachine.hero.IsGroundDetected() == false)
        {
            stateMachine.ChangeState(stateMachine.AirState);

        }// д�����Ϊ�˷�ֹ�ڿ���ֱ���л�ΪmoveState�ˡ�

        if (PlayerInputSystem.MainInstance.Jump && stateMachine.hero.IsGroundDetected())
        {
            stateMachine.ChangeState(stateMachine.JumpState);
        }//�ո��л�Ϊ��Ծ״̬
    }
}
