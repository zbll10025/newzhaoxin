using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundState
{
    public IdleState(PlayerStateMachine playerStateMachine):base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        //rb.velocity = new(0, 0);
        anim.SetBool(AnimatorID.HasInputID, false);
        anim.SetBool(AnimatorID.JumpID, false);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (stateMachine.hero.IsWallDetected())
        {
            if (xInput != 0 && xInput != facingDir)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }

        }
        else
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }
        }
    }
}
