using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class FlyMostPlayerCheck : Conditional
{
    public FlyEnemy most;
    public override void OnStart()
    {
        most = GetComponent<FlyEnemy>();    
    }

    public override TaskStatus OnUpdate()
    {
        if (most.playerCheck.findPlayer)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
