using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public string objectName;
    public Rigidbody2D rig;
    public event Action Recycle;
    public int damageValue;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private async void OnTriggerEnter2D(Collider2D collision)
    {  

        if (collision.CompareTag("Player") || collision.CompareTag("Platform"))
        {
            if (rig != null)
            {
                rig.gravityScale = 1;
            }
            if(collision.CompareTag("Player"))
                Attack(collision.gameObject.GetComponent<Hero>());
            await UniTask.Delay(250);
            PoolManger.Instance.Recycle(objectName, this.gameObject);
            Recycle?.Invoke();
        }
        
        //对象池的回收
    }
    public void Attack(Hero hero)
    {
        hero.IsHit(damageValue);
    }

}
//这个是子弹或弓箭打中物体的效果
