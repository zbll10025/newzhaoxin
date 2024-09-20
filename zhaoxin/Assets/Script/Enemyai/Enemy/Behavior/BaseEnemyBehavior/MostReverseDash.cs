using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.UIElements;
using Unity.Mathematics;
public class MostReverseDash : Action
{
    public BaseEnemy most;
    
 
    public bool isDash;

    [Header("–Ë“™…Ë÷√")]

    public float force;
    public bool isChangeLoacscale;

    public override void OnStart()
    {
        most = GetComponent<BaseEnemy>();
    }
    public override TaskStatus OnUpdate()
    {
        return Dash();
    }
    public  TaskStatus Dash()
    { 
        
        
            Vector2 dir = new Vector2();
            
            if (isChangeLoacscale)
            {
                if (!most.isRightLocalscal)
                {
                     dir = new Vector2(-most.transform.localScale.x, 0);
                    
                }
                else
                {
                     dir = new Vector2(most.transform.localScale.x, 0);
                  
                }
            }
           
            most.rig.AddForce(dir*force,ForceMode2D.Impulse);
           
      return TaskStatus.Success;
       
       
      
    }
}
