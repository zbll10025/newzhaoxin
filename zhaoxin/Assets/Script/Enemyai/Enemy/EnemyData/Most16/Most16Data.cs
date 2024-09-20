using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most16Data : LandMost
{
    public GameObject AttackFx;
    public Animator aniFx;
    protected override void Awake()
    {
        base.Awake();
        AttackFx = transform.Find("m16AttackFX").gameObject;
        aniFx = AttackFx.GetComponent<Animator>();
    }

    public override void CancelAniAttack()
    {
        base.CancelAniAttack();
        if (aniFx != null)
        {
            aniFx.SetBool("isAttack", false);
        }
    }

    public void AniFx_isAttackStart()
    {
        if (aniFx != null)
        {
            aniFx.SetBool("isAttack", true);
        }
    }
    
}
