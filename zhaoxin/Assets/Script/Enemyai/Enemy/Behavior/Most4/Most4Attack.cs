using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Assets.Script.Enemy;
public class Most4Attack : Conditional
{
    public Most4Data most4Data;
    public GameObject player;
    public Vector3 mostPosition;
    public Animator ani;
    public override void OnAwake()
    {
        most4Data = GetComponent<Most4Data>();
        player = GameObject.Find("Player");
        mostPosition= most4Data.Enemytransform.position;
        ani = most4Data.ani;
    }
    public override TaskStatus OnUpdate()
    {
        if (most4Data.AttackAreac.isattackarea)
        {
            player = GameObject.Find("Hero");
            mostPosition = most4Data.Enemytransform.position;
            Vector2 direction = (player.transform.position - mostPosition).normalized;
            if (-direction.x > 0)
            {
                most4Data.transform.localScale = new Vector2(1, 1);
            }
            else if (-direction.x < 0)
            {
                most4Data.transform.localScale = new Vector2(-1, 1);
            }
            most4Data.rig.velocity= Vector3.zero;
            return TaskStatus.Success;
        }else
        {
            ani.SetBool("isAttack", false);
            return TaskStatus.Failure;
        }
          
    }
}
