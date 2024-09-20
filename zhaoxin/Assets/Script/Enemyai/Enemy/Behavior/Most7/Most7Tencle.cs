using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most7Tencle : Action
{
    // Start is called before the first frame update
    Most7Data most;
    public override void OnStart()
    {
       most = GetComponent<Most7Data>();
    }
    public override TaskStatus OnUpdate()
    {
        most.GetTencle();
       return TaskStatus.Success;
    }
}
