using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack2 : AttackState
{
    public PrimaryAttack2(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();

        //stateMachine.hero.SlashAndDetect(Attack.AttackType.Slash);
        anim.CrossFadeInFixedTime("PrimaryAttack2", 0, 0);



    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
    }
}
