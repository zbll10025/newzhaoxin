using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpState : PlayerState
{
    private float jumpTimer = 0.2f;
    private bool canJump;

    public JumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool(AnimatorID.JumpID, true);
        canJump = true;
    }
    public override void Exit()
    {
        base.Exit();
        jumpTimer = 0.2f;
    }
    public override void Update()
    {
        base.Update();
        SetGravityScale(1f);
        //如果速度在0.1到-0.1之间，减少重力，使动作流畅
        if(Mathf.Abs(rb.velocity.y)< jumpHandTimeThreshold)
        {
            //减少重力
            SetGravityScale(0.5f);
        }
        if (xInput != 0)
        {
            SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        }
        ChangeState();
    }
    private void ChangeState()
    {
        if (PlayerInputSystem.MainInstance.Jump&&canJump)//持续按下跳跃键
        {
            jumpTimer -= Time.deltaTime;
            if(jumpTimer>0) 
            {
                rb.velocity = new Vector2(rb.velocity.x, stateMachine.hero.jumpForce);//将y轴速度改变
                
                //rb.AddForce(new Vector2(rb.velocity.x, stateMachine.hero.jumpForce), ForceMode2D.Force);
            }
        }
        if(!PlayerInputSystem.MainInstance.Jump) 
        {
            canJump = false;
        }
        if (PlayerInputSystem.MainInstance.PrimaryAttack &&
            PlayerInputSystem.MainInstance.PlayerXMove.y < 0)//下落攻击
        {
            stateMachine.ChangeState(stateMachine.DownAttack);
            return;
        }
        if (rb.velocity.y < 0)//当速度小于0时切换为airState
        {
            stateMachine.ChangeState(stateMachine.AirState);//与其说是airState，不如说是FallState
        }
        if (stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
        
    }
}
