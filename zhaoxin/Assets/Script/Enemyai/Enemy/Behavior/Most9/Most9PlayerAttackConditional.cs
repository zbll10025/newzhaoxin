using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most9PlayerAttackConditional : Conditional
{
    public Most9Data most9Data;
    public bool isAttack;

    public override void OnAwake()
    {
        most9Data = GetComponent<Most9Data>();
    }
    public override TaskStatus OnUpdate()
    {
        isAttack = most9Data.AttackAreac.isattackarea;
        if (isAttack)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
