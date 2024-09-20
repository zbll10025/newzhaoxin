using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Unity.Mathematics;

public class LandEnemyPatrol : Action
{
    [Header("¶ÔÓ¦most")]
    public LandMost Most;
    [Header("Ñ²Âßµã")]
    public Transform A;
    public Transform B;
    public Transform toalTransform;
    public float R=0.5f;
    public Transform[] N = new Transform[2];
    public int cnt = 0;
    public override void OnAwake()
    {
        Most = GetComponent<LandMost>();
        N = new Transform[] { A, B };
        toalTransform = N[0];
    }
    public override TaskStatus OnUpdate()
    {
        return DotPatrol();

    }

    public TaskStatus DotPatrol()
    {   
        
        float distanc = math.abs(Most.Enemytransform.position.x - toalTransform.position.x);
 
        Vector2 direction = (toalTransform.position - Most.Enemytransform.position).normalized;
        if (distanc < R)
        {
            cnt++;
            if (cnt == 2)
            {
                cnt = 0;
            }
            toalTransform = N[cnt];
            return TaskStatus.Success;
        }
        else
        {
           
            Most.currentsSpeed = Most.patorlSpeed;
            Most.rig.velocity = new Vector2(direction.x * Most.patorlSpeed, direction.y);
            if (!Most.isRightLocalscal)
            {
                   if (-direction.x > 0)
                    {
                        Most.transform.localScale = new Vector2(1, 1);
                    }
                    else if (-direction.x < 0)
                    {
                        Most.transform.localScale = new Vector2(-1, 1);
                    }
            }
            else
            {
                if (direction.x > 0)
                {
                    Most.transform.localScale = new Vector2(1, 1);
                }
                else if (direction.x < 0)
                {
                    Most.transform.localScale = new Vector2(-1, 1);
                }
            }
           
        }
        return TaskStatus.Running;

    }

}

