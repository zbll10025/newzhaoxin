using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    public int dashDir;//��̷���
    public DashState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        //stateTimer = player.dashDuration; ����Dash���Ա��ֵ�ֵ
        isDashing = true;
        anim.CrossFadeInFixedTime("Dash", 0, 0);
        TimerManager.MainInstance.GetTimer(stateMachine.hero.dashDuration,EndDash);

    }

    public override void Exit()
    {
        base.Exit();
        isDashing = false;
        SetVelocity(0, rb.velocity.y);//���˳�ʱʹ�ٶ�Ϊ0��ֹ�����������ٶȲ��䵼�µĳ����ƶ�

    }

    public override void Update()
    {
        base.Update();
        dashDir = (int)PlayerInputSystem.MainInstance.PlayerXMove.x;
        if (dashDir == 0)
        {
            dashDir = facingDir;//ֻ�е����û�п��Ʒ���ʱ��ʹ��Ĭ�ϳ���
        }
        //���д��Update���ֹ��x�᷽������ˣ�ͬʱY��д��0���Է�ֹdash��û����ɾʹӿ��е���ȥ��
        SetVelocity(stateMachine.hero.dashSpeed * dashDir, 0);        
    }
    public void EndDash()
    {
        anim.SetTrigger(AnimatorID.EndDashID);
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}
