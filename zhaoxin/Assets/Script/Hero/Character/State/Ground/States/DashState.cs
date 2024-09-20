using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    public int dashDir;//冲刺方向
    public DashState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        //stateTimer = player.dashDuration; 设置Dash可以保持的值
        isDashing = true;
        anim.CrossFadeInFixedTime("Dash", 0, 0);
        TimerManager.MainInstance.GetTimer(stateMachine.hero.dashDuration,EndDash);

    }

    public override void Exit()
    {
        base.Exit();
        isDashing = false;
        SetVelocity(0, rb.velocity.y);//当退出时使速度为0防止动作结束后速度不变导致的持续移动

    }

    public override void Update()
    {
        base.Update();
        dashDir = (int)PlayerInputSystem.MainInstance.PlayerXMove.x;
        if (dashDir == 0)
        {
            dashDir = facingDir;//只有当玩家没有控制方向时才使用默认朝向
        }
        //这个写在Update里，防止在x轴方向减速了，同时Y轴写成0，以防止dash还没有完成就从空中掉下去了
        SetVelocity(stateMachine.hero.dashSpeed * dashDir, 0);        
    }
    public void EndDash()
    {
        anim.SetTrigger(AnimatorID.EndDashID);
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}
