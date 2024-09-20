using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Most1PlayerCheckCondtion :Conditional
{
    public Most1Data most1Data;
    public bool findPlayer;

    public override void OnAwake()
    {
        most1Data = GetComponent<Most1Data>();
    }
    public override TaskStatus OnUpdate()
    {
        findPlayer = most1Data.most1PlayerCheck.findPlayer;
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
