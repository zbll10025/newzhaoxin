using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.Events;

public class Most4Hit : Conditional
{
    public Most4Data most4Data;
    public override TaskStatus OnUpdate()
    {
       
        if (most4Data.ishit){
            return OnHit();
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
    
       
    
    public TaskStatus OnHit()
    {
        return TaskStatus.Success;
    }
}
