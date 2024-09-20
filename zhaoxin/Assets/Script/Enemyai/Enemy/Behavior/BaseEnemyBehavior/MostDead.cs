using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class MostDead : Conditional
{
    public BaseEnemy BaseEnemy;
    public override void OnAwake()
    {
         BaseEnemy = GetComponent<BaseEnemy>();
    }
    public override TaskStatus OnUpdate()
    {
        if (BaseEnemy.isdead)
        {
            return OnDead();
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
    public TaskStatus OnDead()
    {
        return TaskStatus.Success;
    }
}
