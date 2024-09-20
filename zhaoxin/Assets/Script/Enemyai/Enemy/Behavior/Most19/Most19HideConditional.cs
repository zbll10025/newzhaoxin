using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most19HideConditional :Conditional
{ 
    public Most19Data most19Data;
    public override void OnAwake()
    {
        most19Data =  GetComponent<Most19Data>();   
    }

    public override TaskStatus OnUpdate()
    {

        if (!most19Data.isHide)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
