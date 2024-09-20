using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Most4PlayerCheckCondition : Conditional
{
   public Most4Data most4Data;
    public bool findPlayer;

    public override void OnAwake()
    {
        most4Data = GetComponent<Most4Data>();
    }
    public override TaskStatus OnUpdate()
    {
      findPlayer = most4Data.Most4PlayerCheck.findPlayer;
        if (findPlayer)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }

}
