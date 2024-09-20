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
        
        //����صĻ���
    }
}
//������ӵ��򹭼����������Ч��
