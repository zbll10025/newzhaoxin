using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeState : PlayerState
{
    public float chargeTime = 1f; // 蓄力时间
    private float currentChargeTime = 0f; // 当前蓄力时间

    float attackDir;
    public ChargeState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        isCharge = true;
        anim.CrossFadeInFixedTime("Charge", 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        isCharge = false;
        currentChargeTime = 0f;//重置蓄力值
        
    }
    public override void Update()
    {
        base.Update();
        //FlipController(PlayerInputSystem.MainInstance.PlayerXMove.x); //选择攻击方向
        // 增加当前蓄力时间
        SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        if (currentChargeTime < chargeTime)
        {
            currentChargeTime += Time.deltaTime;
            if (!PlayerInputSystem.MainInstance.Charge)//没到达蓄力时间
            {
                anim.CrossFadeInFixedTime("Idle", 0, 0);
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
        else
        {
            if (!PlayerInputSystem.MainInstance.Charge)//到达蓄力时间
            {
                stateMachine.ChangeState(stateMachine.ChargeAttack1);
                anim.SetTrigger(AnimatorID.Charge1ID);
            }
        }

    }
}
