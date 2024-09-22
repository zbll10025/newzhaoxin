using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most7ReverseWalkAttack : Action
{
    public Most7Data most;
    public float bulletspeed=20f;
    public override void OnAwake()
    {
        most = GetComponent<Most7Data>();   
    }

    public override TaskStatus OnUpdate()
    {
        most.LunchBullet(bulletspeed);
        return TaskStatus.Success;
    }
}
