using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
public class FlyMostApproach : Action
{
    public FlyEnemy most;
    public Rigidbody2D rig;
    public float R = 5f;
    public override void OnStart()
    {
        most = GetComponent<FlyEnemy>();
        rig = GetComponent<Rigidbody2D>();
    }
    public override TaskStatus OnUpdate()
    {
        most.FixDirc();
        if (most.playerDistance < R)
        {
            rig.velocity =  Vector2.zero;
            return TaskStatus.Success;

        }
        else
        {
            rig.velocity = new Vector2(most.playerDirection.x * most.rushSpeed, most.playerDirection.y * most.rushSpeed); 
            return TaskStatus.Running;
        }
        
    }
}
