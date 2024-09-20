using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most1Data : LandMost
{
    public Most1PlayerCheck most1PlayerCheck;
    protected override void Awake()
    {
        base.Awake();
        most1PlayerCheck = transform.Find("PlayerCheck").gameObject.GetComponent<Most1PlayerCheck>();
    }
}
