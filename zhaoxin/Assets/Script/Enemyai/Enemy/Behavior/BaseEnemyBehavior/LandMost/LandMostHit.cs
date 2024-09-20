using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class LandMostHit : Conditional
{
    public BaseEnemy mostData;

    public override void OnAwake()
    {
        mostData = GetComponent<BaseEnemy>();
    }
    public override TaskStatus OnUpdate()
    {

        if (mostData.ishit)
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
