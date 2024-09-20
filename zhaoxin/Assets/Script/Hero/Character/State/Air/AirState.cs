using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : PlayerState
{
    float maxFallSpeed = 10f;
    public AirState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        anim.SetBool(AnimatorID.JumpID,true);
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        
        SetGravityScale(1f);
        //如果速度再0.1到-0.1之间，减少重力，使动作流畅
        if (Mathf.Abs(rb.velocity.y) < jumpHandTimeThreshold)
        {
            //减少重力
            SetGravityScale(0.5f);
        }
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));//设置最大下落速度
        if (xInput != 0&&!isFirstLand)
        {
            SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        }
        if (isFirstLand)//第一次落地不能移动
        {
            ZeroVelocity();
        }
        if (PlayerInputSystem.MainInstance.PrimaryAttack &&
            PlayerInputSystem.MainInstance.PlayerXMove.y < 0)//下落攻击
        {
            stateMachine.ChangeState(stateMachine.DownAttack);
            return;
        }
        if(isFirstLand&& stateMachine.hero.IsGroundDetected())
        {
            
            stateMachine.ChangeState(stateMachine.FirstLandState);
            return;
        }
        if (stateMachine.hero.IsGroundDetected())//触地
        {
            ZeroVelocity();
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if(stateMachine.hero.IsWallDetected())//触墙
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        anim.SetBool(AnimatorID.JumpID, false);
    }
}
