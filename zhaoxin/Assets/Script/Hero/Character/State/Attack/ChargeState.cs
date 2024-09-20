using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeState : PlayerState
{
    public float chargeTime = 1f; // ����ʱ��
    private float currentChargeTime = 0f; // ��ǰ����ʱ��

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
        currentChargeTime = 0f;//��������ֵ
        
    }
    public override void Update()
    {
        base.Update();
        //FlipController(PlayerInputSystem.MainInstance.PlayerXMove.x); //ѡ�񹥻�����
        // ���ӵ�ǰ����ʱ��
        SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        if (currentChargeTime < chargeTime)
        {
            currentChargeTime += Time.deltaTime;
            if (!PlayerInputSystem.MainInstance.Charge)//û��������ʱ��
            {
                anim.CrossFadeInFixedTime("Idle", 0, 0);
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
        else
        {
            if (!PlayerInputSystem.MainInstance.Charge)//��������ʱ��
            {
                stateMachine.ChangeState(stateMachine.ChargeAttack1);
                anim.SetTrigger(AnimatorID.Charge1ID);
            }
        }

    }
}
