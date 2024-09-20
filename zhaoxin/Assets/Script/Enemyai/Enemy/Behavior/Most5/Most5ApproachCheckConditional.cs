using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most5ApproachCheckConditional : Conditional
{
   public Most5Data most5;
    public  bool  isApproach = false;

    public override void OnAwake()
    {
        most5= GetComponent<Most5Data>(); 
    }
    public override TaskStatus OnUpdate()
    {
       isApproach = most5.approachCheck.isApporach;
        if (isApproach)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
