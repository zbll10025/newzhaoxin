using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class LandMostChangeDir : Action
{
    public override TaskStatus OnUpdate()
    {
        this.transform.localScale = new Vector3(-this.transform.localScale.x,1,1);
        return TaskStatus.Success;
    }
}
