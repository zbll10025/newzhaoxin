using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttackState : AttackState
{
    public UpAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.CrossFadeInFixedTime("UpAttack", 0, 0);
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
