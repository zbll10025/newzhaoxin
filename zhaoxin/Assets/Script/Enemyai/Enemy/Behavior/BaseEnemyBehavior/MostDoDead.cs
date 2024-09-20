using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostDoDead :Action
{
    public override TaskStatus OnUpdate()
    {
        GetComponent<BaseEnemy>().isdead = true;
        return TaskStatus.Success;
    }}
