using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : PlayerState
{
    float stateTimer;
    public WallJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.1f;//定时器，在一定时间后进入idle
        SetVelocity(7 * -facingDir, stateMachine.hero.jumpForce);//跳是向反方向跳
        
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        if (xInput != 0)
        {
            SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        }
        if (stateTimer < 0) 
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if (stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
        if (stateMachine.hero.IsGroundDetected())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
