using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using MemoryPack;
public class FlyMostPotral :Action
{
    public FlyEnemy most;
    public Rigidbody2D rig;
    public Vector3 totalPosition;
    public float R = 0.25f;
    public override void OnAwake()
    {
         most = GetComponent<FlyEnemy>();
        rig = GetComponent<Rigidbody2D>();
        totalPosition = most.GetRandomPosition();
    }

    public override TaskStatus OnUpdate()
    {
        float distance = Vector2.Distance(totalPosition,transform.position);
        Vector2 dirc = (totalPosition - transform.position).normalized;
        Debug.Log(dirc);
        if (distance < R)
        {
            totalPosition = most.GetRandomPosition();
            rig.velocity = Vector2.zero;
            return TaskStatus.Success;
        }
        else
        {
            most.UpdataDirc(totalPosition);
            rig.velocity = new Vector2(dirc.x*most.patorlSpeed, dirc.y* most.patorlSpeed);
            return TaskStatus.Running;
        }
        
    }
}
