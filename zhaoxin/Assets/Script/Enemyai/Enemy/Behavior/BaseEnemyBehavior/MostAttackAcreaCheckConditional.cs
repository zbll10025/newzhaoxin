using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostAttackAcreaCheckConditional : Conditional
{
    public BaseEnemy mostData;
    public override void OnAwake()
    {
        mostData = GetComponent<BaseEnemy>();
    }

    public override TaskStatus OnUpdate()
    {

       return  AttackAcreaJud();

    }

    public TaskStatus AttackAcreaJud()
    {

        if (mostData.AttackAreac.isattackarea)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
