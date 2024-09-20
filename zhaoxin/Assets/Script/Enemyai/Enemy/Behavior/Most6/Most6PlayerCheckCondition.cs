using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most6PlayerCheckCondition :Conditional
{
    public Most6Data most6Data;
    public bool findPlayer;

    public override void OnAwake()
    {
        most6Data = GetComponent<Most6Data>();
    }
    public override TaskStatus OnUpdate()
    {
        findPlayer = most6Data.PlayerCheck.findPlayer;
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
