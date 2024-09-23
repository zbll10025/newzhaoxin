using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : AttackState
{
    public PrimaryAttack(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();

        //stateMachine.hero.SlashAndDetect(Attack.AttackType.Slash);
        anim.CrossFadeInFixedTime("PrimaryAttack1", 0, 0);
        
        
        
    }

    public override void Exit()
    {
        base.Exit();
        
    }
    
    public override void Update()
    {
        base.Update();
        if (PlayerInputSystem.MainInstance.PrimaryAttack)//¶þ¶Î¹¥»÷
        {
            stateMachine.ChangeState(stateMachine.PrimaryAttack2);
        }
    }
}
