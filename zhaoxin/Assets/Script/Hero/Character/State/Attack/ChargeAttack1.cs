using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack1 : PlayerState
{
    public ChargeAttack1(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        triggerCalled = false;
    }
    public override void Update()
    {
        base.Update();
        ZeroVelocity();
        if (triggerCalled)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
