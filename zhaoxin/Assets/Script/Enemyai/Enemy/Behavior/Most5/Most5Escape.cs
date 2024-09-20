using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Cysharp.Threading.Tasks;
public class Most5Escape : Action
{
    public Most5Data most5Data;
    public Rigidbody2D rig;
    public bool isStart;
    public float rush;
    public Vector3 enemydir;
    public Vector2 dir;
    public float time = 0;
    [Header("设定逃跑时间")]
    public float totalTime;
    public override  TaskStatus OnUpdate()
    {

        
        if (!isStart){
           
            isStart = true;
            most5Data = GetComponent<Most5Data>();
            rig = GetComponent<Rigidbody2D>();
            rush = most5Data.rushSpeed;
            most5Data.gameObject.transform.localScale = new Vector3(-most5Data.gameObject.transform.localScale.x,1,1);
            dir = new Vector2(-most5Data.gameObject.transform.localScale.x, 0);
        }
        if (most5Data.isEscape)
        {
            return TaskStatus.Failure;
        }

        time += Time.deltaTime;
        if (time > totalTime||!most5Data.isGround)
        {
            time = 0;
            rig.velocity = Vector2.zero;
            most5Data.gameObject.transform.localScale = new Vector3(-most5Data.gameObject.transform.localScale.x, 1, 1);
            most5Data.isEscape = true;
            
            return TaskStatus.Success;
        }
        else
        {
            Move();
        }

        return TaskStatus.Running;
    }

    public void Move()
    {
        rig.velocity = new Vector2 (rush*dir.x,0);
    }
}
