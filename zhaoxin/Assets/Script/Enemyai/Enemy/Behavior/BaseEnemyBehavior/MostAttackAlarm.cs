using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostAttackAlarm :Action
{

    public BaseEnemy most;
    public override TaskStatus OnUpdate()
    {
        most = GetComponent<BaseEnemy>();
        most.attackAlarm.gameObject.SetActive(true);
        return TaskStatus.Success;
    }
}
