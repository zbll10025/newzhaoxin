using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class LandDircBehind :Action
{
   public BaseEnemy landEnemy;
    public override void OnAwake()
    {
        landEnemy = GetComponent<BaseEnemy>();
    }
    public override TaskStatus OnUpdate()
    {

        return FixDirc();
        
        
    }

    public TaskStatus FixDirc()
    { 
        if (!landEnemy.isRightLocalscal)
        {
            if (-landEnemy.playerDirection.x > 0)
            {
                landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (landEnemy.playerDirection.x > 0)
            {
                landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
          return TaskStatus.Success;
    }
}
