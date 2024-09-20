using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most12Data :LandMost
{
    public AttackAreac attackAreac;
   
    protected override void Awake()
    {
        base.Awake();
        attackAreac = transform.Find("AttackAcrea").GetComponent<AttackAreac>();
    }

   
    
}
