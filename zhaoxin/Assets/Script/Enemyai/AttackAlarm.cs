using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAlarm : MonoBehaviour
{
    public Animator anim;
    public string _name = "AttackAlarm";
    public bool isnoPoolobj;
    public void CancelAttackAlarm()
    {
        if (isnoPoolobj)
        {
            this.gameObject.SetActive(false);

        }
        else
        {
            PoolManger.Instance.Recycle("AttackAlarm", this.gameObject);
        }
        
        
    }
}
