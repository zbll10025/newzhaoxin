using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most8AttackAcreaCoditional : Conditional
{
    public Most8Data most8Data;
    public bool isAttack;

    public override void OnAwake()
    {
        most8Data = GetComponent<Most8Data>();
    }
    public override TaskStatus OnUpdate()
    {
       isAttack = most8Data.AttackAreac.isattackarea;
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
