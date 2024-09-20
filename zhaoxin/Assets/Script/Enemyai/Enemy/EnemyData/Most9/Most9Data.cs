using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most9Data : LandMost
{
    protected override void Awake()
    {
        base.Awake();
        AttackAreac = transform.Find("AttackAcrea").GetComponent<AttackAreac>();
    }
}
