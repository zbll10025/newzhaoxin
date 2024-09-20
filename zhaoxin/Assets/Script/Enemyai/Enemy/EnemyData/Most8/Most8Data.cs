using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most8Data :LandMost
{
    public PlayerCheck Most8PlayerCheck;
    public GameObject fireObject;
    public Animator firAni;
    protected override void Awake()
    {
        base.Awake();
        
        AttackAreac = GameObject.Find("Most8AttackAcrea").GetComponent<AttackAreac>();
        Most8PlayerCheck = transform.Find("PlayerCheck").gameObject.GetComponent<PlayerCheck>();
        fireObject = transform.Find("m8FirebreathFX").gameObject;
        firAni = fireObject.GetComponent<Animator>();
    }

    public void OnstratFire()
    {
        firAni.SetBool("isAttack", true);
    }
}
