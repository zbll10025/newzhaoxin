using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most12AttackAcreaConditional : Conditional
{
    public Most12Data mostData;
    public override void OnAwake()
    {
      mostData = GetComponent<Most12Data>();
    }

    public override TaskStatus OnUpdate()
    {

        if (mostData.attackAreac.isattackarea)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
       
    }
}
