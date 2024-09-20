using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostBehindIsPlayer : Conditional
{
    public BaseEnemy most;
    public override void OnStart()
    {
        most = GetComponent<BaseEnemy>();
    }
    public override TaskStatus OnUpdate()
    {
        bool isbehind = most.BehindPlayerCheck();
        if (isbehind)
        {

            return TaskStatus.Success;
        }
        else { 
        
             return TaskStatus.Failure;
        }
    }

}
