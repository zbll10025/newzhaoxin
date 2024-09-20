using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most6AttackA : Most6Attack
{

    public void isAttackA()
    {
        GameObject a = PoolManger.Instance.Get("Rem6Projectile", "Prefabs/Enemy/ReEnemy/Project/Rem6Projectile");
        Vector3 trnf = this.gameObject.transform.position;
        a.transform.position = trnf;
        a.transform.eulerAngles = lunchAngel;
        a.SetActive(true);
        a.GetComponent<Rigidbody2D>().AddForce(dirce * force, ForceMode2D.Impulse);
    }
}
