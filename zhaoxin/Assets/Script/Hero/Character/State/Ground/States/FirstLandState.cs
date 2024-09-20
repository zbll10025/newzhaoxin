using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLandState : PlayerState
{
    public FirstLandState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log(true);
        anim.Play("FirstLand");
        
        triggerCalled = false;
    }

    public override void Exit()
    {
        base.Exit();
        isFirstLand = false;
    }
    public override void Update()
    {
        if(triggerCalled) 
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
