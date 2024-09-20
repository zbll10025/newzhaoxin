using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Assets.Script.Enemy;
using Unity.Mathematics;
public class LandMostRush : Action
{
    public LandMost most;
    public Vector3 mostPosition;
    public GameObject player;
    public Vector2 playerDirection;
    public float playerDistance;
    public float R;
    public bool isRightLocalscale;
    public override void OnAwake()
    {
        most = GetComponent<LandMost>();
        most.currentsSpeed = most.rushSpeed;
         player =most.player;
        isRightLocalscale = most.isRightLocalscal;
    }
    public override TaskStatus OnUpdate()
    {

        return Run();
    }

    public TaskStatus Run()
    {
        playerDirection = most.playerDirection;
        playerDistance = most.playerDistance;

        if (!isRightLocalscale) { 

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

        if (playerDistance > R)
        {
            most.rig.velocity = new Vector2(playerDirection.x * most.rushSpeed, most.rig.velocity.y);
        }
        else
        {
            most.rig.velocity = Vector2.zero;
            return TaskStatus.Failure;
        }


        return TaskStatus.Success;

    }

    public TaskStatus Run_ReturnRunning()
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

        if (playerDistance > R)
        {
            most.rig.velocity = new Vector2(playerDirection.x * most.rushSpeed, most.rig.velocity.y);
            return TaskStatus.Running;
        }
        else
        {
            most.rig.velocity = Vector2.zero; 
            return TaskStatus.Success;
        }


       

    }
}
