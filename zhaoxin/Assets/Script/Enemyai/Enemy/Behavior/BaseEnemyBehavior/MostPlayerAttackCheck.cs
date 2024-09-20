using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostPlayerAttackCheck : Conditional
{
    BaseEnemy most;
    public float checkTime;
    float time = 0;
    public override void OnStart()
    {
        
        most = GetComponent<BaseEnemy>();
    }

    public override TaskStatus OnUpdate()
    {
        time += Time.deltaTime;
        if (time > checkTime)
        {
            time = 0;
            return TaskStatus.Failure;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                time = 0;
                return TaskStatus.Success;
            }
            return TaskStatus.Running;  
        }
    }
}
