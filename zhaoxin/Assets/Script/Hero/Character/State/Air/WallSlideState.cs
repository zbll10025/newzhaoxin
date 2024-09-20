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
        if(PlayerInputSystem.MainInstance.Jump&&busyForTimer>=0.3f)//��ǽ��
        {
            stateMachine.ChangeState(stateMachine.WallJumpState);
            return;//���ڶ��Ǵ�wallSlide���룬����Space���������State������return����
        }
        if (xInput != 0 && facingDir != xInput)//��������Ϊ�˱�֤��û�нӴ������ʱ��Ҳ�����л���idleState��ʹ���Ƹ������
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if (stateMachine.hero.IsGroundDetected())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        rb.velocity = new Vector2(0, rb.velocity.y * .7f);//���û����ʱ��ǽ�ϻ���ʱ�ٶȼ���һ��
    }
}
