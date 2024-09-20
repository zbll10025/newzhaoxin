using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most5PlayerCheckCondition : Conditional
{
    public Most5Data most5Data;
    public bool findPlayer;

    public override void OnAwake()
    {
        most5Data = GetComponent<Most5Data>();
    }
    public override TaskStatus OnUpdate()
    {
        findPlayer = most5Data.most1PlayerCheck.findPlayer;
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
