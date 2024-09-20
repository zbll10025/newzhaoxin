using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most4Data : LandMost
{
    public Most4PlayerCheck Most4PlayerCheck;

    protected override void Awake()
    {
        base.Awake();
        AttackAreac = GameObject.Find("AttackAcrea").GetComponent<AttackAreac>();
        Most4PlayerCheck = transform.Find("PlayerCheck").gameObject.GetComponent<Most4PlayerCheck>();
    }
}
