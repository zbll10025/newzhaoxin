using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most7ReverseWalkAttack : Action
{
    public Most7Data most;
    public override void OnAwake()
    {
        most = GetComponent<Most7Data>();   
    }

    public override TaskStatus OnUpdate()
    {
        most.LunchBullet();
        return TaskStatus.Success;
    }
}
