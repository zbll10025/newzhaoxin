using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostReverseWalk : Action
{
    public 
    BaseEnemy most;
    float speed;
    public float totaltime;
    public float time = 0;
    public override void OnAwake()
    {
        most =  GetComponent<BaseEnemy>();  
        speed =  most.patorlSpeed;   
    }

    public override TaskStatus OnUpdate()
    {
        return ReverseWalk();
    }

    public TaskStatus ReverseWalk()
    {
        Vector2 walkDir = new Vector2(-most.playerDirection.x, 0);
        most.FixDirc();
        most.rig.velocity = new Vector2(walkDir.x * speed,0);
        if (time < totaltime)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
      
    }
}
