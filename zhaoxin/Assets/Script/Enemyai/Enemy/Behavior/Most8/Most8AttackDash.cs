using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most8AttackDash : LandMostRush
{
    public float ZBtime;
    public float time;

    public override TaskStatus OnUpdate()
    {
        playerDirection = most.playerDirection;
        playerDistance = most.playerDistance;

        if (!isRightLocalscale)
        {

            if (-playerDirection.x > 0)
            {
                most.transform.localScale = new Vector2(1, 1);
            }
            else if (-playerDirection.x < 0)
            {
                most.transform.localScale = new Vector2(-1, 1);
            }

        }
        else
        {
            if (playerDirection.x > 0)
            {
                most.transform.localScale = new Vector2(1, 1);
            }
            else if (playerDirection.x < 0)
            {
                most.transform.localScale = new Vector2(-1, 1);
            }
        }


        most.currentsSpeed = most.rushSpeed;

        time += Time.deltaTime;
        if (time > ZBtime)
        {
            most.isdead =true;
            GetComponent<Rigidbody2D>().velocity.Set(0, 0);

            return TaskStatus.Running;

        }

        if (playerDistance > R)
        {
            most.rig.velocity = new Vector2(playerDirection.x * most.rushSpeed, most.rig.velocity.y);
            return TaskStatus.Running;
        }
        else
        {
            most.rig.velocity = Vector2.zero;
            most.isdead = true;
            return TaskStatus.Success;
        }

    }

}
