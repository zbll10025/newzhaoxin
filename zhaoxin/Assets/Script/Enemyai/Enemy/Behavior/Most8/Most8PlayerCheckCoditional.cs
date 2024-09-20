using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most8PlayerCheckCoditional : Conditional
{
    public Most8Data most8Data;
    public bool findPlayer;

    public override void OnAwake()
    {
        most8Data = GetComponent<Most8Data>();
    }
    public override TaskStatus OnUpdate()
    {
        findPlayer = most8Data.Most8PlayerCheck.findPlayer;
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
