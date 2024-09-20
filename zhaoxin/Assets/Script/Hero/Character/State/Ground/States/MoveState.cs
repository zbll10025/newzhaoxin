using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : GroundState
{
    public MoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool(AnimatorID.HasInputID, true);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        if (xInput == 0 || stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

}
