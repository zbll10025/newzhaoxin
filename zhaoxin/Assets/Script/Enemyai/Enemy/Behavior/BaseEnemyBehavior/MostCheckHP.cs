using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostCheckHP : Conditional
{
    public BaseEnemy baseEnemy;
    public float totalHp;
    public CompareSelect select;
    public override void OnAwake()
    {
        baseEnemy = GetComponent<BaseEnemy>();
    }
    public override TaskStatus OnUpdate()
    {
        float enemyHp =baseEnemy.hp;

        switch (select) { 
        case CompareSelect.less:
                if (enemyHp < totalHp)
                {
                    return TaskStatus.Success;
                }
                else
                {
                    return TaskStatus.Failure;
                }
        case CompareSelect.over:
                if (enemyHp >=totalHp)
                {
                    return TaskStatus.Success;
                }
                else
                {
                    return TaskStatus.Failure;
                }
        }

       return TaskStatus.Failure;
    }
}
