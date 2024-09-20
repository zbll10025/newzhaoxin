using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public string objectName;
    public Rigidbody2D rig;
    public event Action Recycle;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.CompareTag("Player") || collision.CompareTag("Platform"))
        {
            if (rig != null)
            {
                rig.gravityScale = 1;
            }
            PoolManger.Instance.Recycle(objectName, this.gameObject);
            Recycle?.Invoke();
        }
        
        //对象池的回收
    }
}
//这个是子弹或弓箭打中物体的效果
