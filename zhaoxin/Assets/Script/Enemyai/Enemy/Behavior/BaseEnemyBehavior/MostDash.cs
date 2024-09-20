using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostDash : Action
{
    public BaseEnemy most;
    public Rigidbody2D rig;

    public override void OnAwake()
    {
       most = GetComponent<LandMost>();
       rig = GetComponent<Rigidbody2D>();
    }

    public override TaskStatus OnUpdate()
    {
        return Dash();
    }

    //³åÏòÍæ¼Ò
    public virtual TaskStatus Dash()
    {
        most.FixDirc();
        Vector2 dir = most.playerDirection;
        rig.AddForce(dir * most.dashForce, ForceMode2D.Impulse);
        return TaskStatus.Success;
    }
}
