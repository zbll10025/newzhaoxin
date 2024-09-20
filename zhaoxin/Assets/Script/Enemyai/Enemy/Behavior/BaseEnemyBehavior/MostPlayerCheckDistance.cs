using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
public class MostPlayerCheckDistance : Conditional
{
    public BaseEnemy most;
    public float  totalDistance;
    public CompareSelect compareSelect;
    public override void OnStart()
    {
        most = GetComponent<BaseEnemy>();
    }

    public override TaskStatus OnUpdate()
    {
        if (compareSelect == CompareSelect.less)
        {
            if (most.playerDistance <= totalDistance)
            {
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Failure;
            }
        }
        else {

            if (most.playerDistance >= totalDistance)
            {
                return TaskStatus.Success;
            }else
            {
                return TaskStatus.Failure;
            }
        
        }
    }
}
