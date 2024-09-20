using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most6PlayerApproachCheck : Conditional
{
   public Most6Data most6Data;
    public bool isApproach;
    public override void OnAwake()
    {
       most6Data = GetComponent<Most6Data>();

    }

    public override TaskStatus OnUpdate()
    {
        if (most6Data == null)
        {
            most6Data = GetComponent<Most6Data>();
        }
        isApproach = most6Data.PlayerApporach.findPlayer;

        if (isApproach) {

            return TaskStatus.Success;
        }
        else { 
            return TaskStatus.Failure;
            }

        
    }
}
