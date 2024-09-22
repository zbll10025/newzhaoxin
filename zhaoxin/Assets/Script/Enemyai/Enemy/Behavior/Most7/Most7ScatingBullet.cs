using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most7ScatingBullet :Action
{
    Most7Data most;
    public float force;
    public override void OnStart()
    {
        most   = GetComponent<Most7Data>();
        most.ScatingBullet(force);
    }

  
}
