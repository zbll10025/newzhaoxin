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
        //����ٶ���0.1��-0.1֮�䣬����������ʹ��������
        if (Mathf.Abs(rb.velocity.y) < jumpHandTimeThreshold)
        {
            //��������
            SetGravityScale(0.5f);
        }
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));//������������ٶ�
        if (xInput != 0&&!isFirstLand)
        {
            SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        }
        if (isFirstLand)//��һ����ز����ƶ�
        {
            ZeroVelocity();
        }
        if (PlayerInputSystem.MainInstance.PrimaryAttack &&
            PlayerInputSystem.MainInstance.PlayerXMove.y < 0)//���乥��
        {
            stateMachine.ChangeState(stateMachine.DownAttack);
            return;
        }
        if(isFirstLand&& stateMachine.hero.IsGroundDetected())
        {
            
            stateMachine.ChangeState(stateMachine.FirstLandState);
            return;
        }
        if (stateMachine.hero.IsGroundDetected())//����
        {
            ZeroVelocity();
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if(stateMachine.hero.IsWallDetected())//��ǽ
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
