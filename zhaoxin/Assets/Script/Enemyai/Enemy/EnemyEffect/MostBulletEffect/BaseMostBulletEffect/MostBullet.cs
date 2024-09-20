using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostBullet : MonoBehaviour
{
    public event Action CancelGrivaty;
    public Rigidbody2D rig;
    public bool cancelCancelGrivaty;
    public bool isChangeAngel;
    public float changeAngelSpeed;
    public float angelOffest;

    private AttackEffect attackEffect;
    protected virtual void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        CancelGrivaty += BulletCancelGrivaty;
       attackEffect = GetComponent<AttackEffect>();
        //对象池回收后的操作
       attackEffect.Recycle += ResetBullet;
    }
    private void Update()
    {
      
      if(isChangeAngel)
         ChangeAngel();
    }
    public void Onstart_Force(Vector2 dir, float force)
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(dir * force, ForceMode2D.Impulse);
    }
    public void Onstart_Velocity(Vector2 dir,float speed)
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
    
    public void ChangeAngel()
    {

        if (rig.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rig.velocity.y, rig.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+angelOffest));
        }
    }

    public void BulletCancelGrivaty()
    {
        cancelCancelGrivaty = true;
        this.rig.gravityScale = 0;
        //CancelGrivaty -= BulletCancelGrivaty;
    }

    public void OnstartCancelGrivaty()
    {
        CancelGrivaty?.Invoke();
    }

    public void ResetBullet()
    {
        //Debug.Log("111111");
        rig.gravityScale = 1;
        angelOffest = 0;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = new Vector3(1, 1, 1);
    }
}
