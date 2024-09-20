using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most19Dash : Action
{
    public LandMost landMost;
    public override TaskStatus OnUpdate()
    {
        landMost = GetComponent<LandMost>();
        landMost.FixDirc();
        GetComponent<Rigidbody2D>().AddForce(landMost.playerDirection * landMost.dashForce, ForceMode2D.Impulse);
        return TaskStatus.Success;
    }
}
