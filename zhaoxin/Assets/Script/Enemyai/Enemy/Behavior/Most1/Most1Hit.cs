using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Most1Hit : Conditional
{
    public Most1Data most1Data;

    public override void OnAwake()
    {
        most1Data = GetComponent<Most1Data>();
    }
    public override TaskStatus OnUpdate()
    {

        if (most1Data.ishit)
        {
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
