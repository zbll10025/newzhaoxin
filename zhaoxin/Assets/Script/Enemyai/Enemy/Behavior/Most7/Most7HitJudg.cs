using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Unity.VisualScripting;
public class Most7HitJudg : Action
{
    BaseEnemy baseEnemy;
    Animator ani;
    public override void OnStart()
    {
        baseEnemy = GetComponent<BaseEnemy>();
        ani = GetComponent<Animator>();
    }
    //判断在地上受伤/空中受伤
    public override TaskStatus OnUpdate()
    {

        if (baseEnemy.isGround)
        {
            ani.SetTrigger("isHit");
        }
        else
        {
            ani.SetTrigger("isHitOnAir");
        }
        return TaskStatus.Success;
    }
}
