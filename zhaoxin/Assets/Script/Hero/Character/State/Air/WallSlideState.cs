using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideState : PlayerState
{
    private float busyForTimer;
    public WallSlideState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.CrossFadeInFixedTime("Slide", 0, 0);

    }

    public override void Exit()
    {
        base.Exit();
        anim.SetTrigger(AnimatorID.SlideOutID);
        busyForTimer = 0f;
    }
    public override void Update()
    {
        base.Update();
        busyForTimer += Time.deltaTime;
        if(PlayerInputSystem.MainInstance.Jump&&busyForTimer>=0.3f)//蹬墙跳
        {
            stateMachine.ChangeState(stateMachine.WallJumpState);
            return;//由于都是从wallSlide进入，光摁Space会进入其他State，故由return控制
        }
        if (xInput != 0 && facingDir != xInput)//这样做是为了保证在没有接触地面的时候也可以切换回idleState，使控制更加灵活
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if (stateMachine.hero.IsGroundDetected())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        rb.velocity = new Vector2(0, rb.velocity.y * .7f);//玩家没控制时在墙上滑行时速度减慢一点
    }
}
