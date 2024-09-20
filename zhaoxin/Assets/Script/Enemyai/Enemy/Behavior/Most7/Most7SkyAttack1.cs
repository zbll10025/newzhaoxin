using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most7SkyAttack1 :Conditional
{ 
    public Most7Data most;
    public float bulletSpeed;
    public override void OnAwake()
    {
        most = GetComponent<Most7Data>();
    }

    public override TaskStatus OnUpdate()
    {
        most.LunchBullet(bulletSpeed);
        most.LunchThreeBullet();
        return TaskStatus.Success;
    }
}
