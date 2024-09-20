using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAttack : AttackState
{
    public DownAttack(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        anim.CrossFadeInFixedTime("DownAttack", 0, 0);
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
