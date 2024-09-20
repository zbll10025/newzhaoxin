using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Most10AttackApproach :LandMostRush
{
    public override TaskStatus OnUpdate()
    {
        return Run_ReturnRunning();
    }
}
