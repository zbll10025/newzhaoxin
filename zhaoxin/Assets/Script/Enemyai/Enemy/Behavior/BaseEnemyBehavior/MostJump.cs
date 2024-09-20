using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityRigidbody;
using BehaviorDesigner.Runtime.Tasks.Unity.Math;
using UnityEngine.Rendering;
using BehaviorDesigner.Runtime;
public class MostJump : Action
{
    public BaseEnemy most;
    public Behavior behavior;
    [Header("需要设置")]
    public bool isjumpPlayer;
    public bool isReverseMostDirc;
    public bool isjumpMostDirc;
    public bool isNeddJumpTime;
    public float jumpDistance;
    public float jumpForce;
    public float jumpHeight;
    
      public override void OnStart()
    {
        most = GetComponent<BaseEnemy>();
        behavior = GetComponent<Behavior>();
    }

    public override TaskStatus OnUpdate()
    {
      CalculatorVelcoityX();
    return TaskStatus.Success;
    }
    #region 考虑重力的抛物线运动
     public void CalculatorVelcoityX()
        {
        if (isjumpPlayer)
        {
            jumpDistance =  most.player.transform.position.x - this.transform.position.x;
        }
            float mass = most.rig.mass;
            float longlenth = math.sqrt(jumpDistance*jumpDistance+jumpHeight*jumpHeight);
            float x= jumpDistance/longlenth; float y= jumpHeight/longlenth;
            Vector2 forward = new Vector2 (x,y);
        if (isjumpMostDirc)
        {
            if (most.isRightLocalscal)
            {
                forward = new Vector2 (x*most.transform.localScale.x,y);
            }
            else
            {
                forward = new Vector2 (-x*most.transform.localScale.x,y);
            }
        }
        if (isReverseMostDirc)
        {
            if (most.isRightLocalscal)
            {
                forward = new Vector2(-x * most.transform.localScale.x, y);
            }
            else
            {
                forward = new Vector2(x * most.transform.localScale.x, y);
            }

        }
            if (jumpForce == 0)
            {
                float time = math.sqrt((2 * jumpHeight) / 9.8f);
            if (isNeddJumpTime)
            {
                behavior.SetVariableValue("jumpTime", time);
            }
                Debug.Log(time);
                jumpForce = (jumpDistance * mass) / (x * time);
            }
            
            most.rig.AddForce(forward*jumpForce, ForceMode2D.Impulse);
           
       
        }
    #endregion
   
}
