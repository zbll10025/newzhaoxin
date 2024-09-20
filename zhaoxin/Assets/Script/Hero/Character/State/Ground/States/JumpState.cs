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
        //����ٶ���0.1��-0.1֮�䣬����������ʹ��������
        if(Mathf.Abs(rb.velocity.y)< jumpHandTimeThreshold)
        {
            //��������
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
        if (PlayerInputSystem.MainInstance.Jump&&canJump)//����������Ծ��
        {
            jumpTimer -= Time.deltaTime;
            if(jumpTimer>0) 
            {
                rb.velocity = new Vector2(rb.velocity.x, stateMachine.hero.jumpForce);//��y���ٶȸı�
                
                //rb.AddForce(new Vector2(rb.velocity.x, stateMachine.hero.jumpForce), ForceMode2D.Force);
            }
        }
        if(!PlayerInputSystem.MainInstance.Jump) 
        {
            canJump = false;
        }
        if (PlayerInputSystem.MainInstance.PrimaryAttack &&
            PlayerInputSystem.MainInstance.PlayerXMove.y < 0)//���乥��
        {
            stateMachine.ChangeState(stateMachine.DownAttack);
            return;
        }
        if (rb.velocity.y < 0)//���ٶ�С��0ʱ�л�ΪairState
        {
            stateMachine.ChangeState(stateMachine.AirState);//����˵��airState������˵��FallState
        }
        if (stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
        
    }
}
