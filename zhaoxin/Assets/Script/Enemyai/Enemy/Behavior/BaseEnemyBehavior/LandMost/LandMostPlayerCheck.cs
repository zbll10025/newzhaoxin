using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class LandMostPlayerCheck : Conditional
{
    public LandMost landmost;
    public bool isFindPlayer;
    public override void OnAwake()
    {
        landmost = GetComponent<LandMost>();
    }

    public override TaskStatus OnUpdate()
    {
        isFindPlayer = landmost.playerCheck.findPlayer;
        if (isFindPlayer)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
