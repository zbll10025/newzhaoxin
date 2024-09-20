using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most8NotApproach : Most8PlayerCheckCoditional
{
    public bool isAttack;
    public override TaskStatus OnUpdate()
    {
        isAttack = most8Data.AttackAreac.isattackarea;
        if (isAttack)
        {
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }
    }
}
