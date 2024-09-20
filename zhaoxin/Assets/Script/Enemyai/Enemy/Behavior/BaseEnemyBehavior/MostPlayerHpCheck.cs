using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostPlayerHpCheck :Conditional
{
    public GameObject Player;
    public float totalHp;
    public float hp;
    public CompareSelect select;
    public override TaskStatus OnUpdate()
    {

        Player = GameObject.Find("Player");
        hp = Player.GetComponent<TestPlayerData>().hp;
        switch (select) {
        case CompareSelect.less:
                if (hp < totalHp)
                {
                    return TaskStatus.Success;
                }
                else
                {

                    return TaskStatus.Failure;


                }
        case CompareSelect.over:
                if (hp>=totalHp)
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
