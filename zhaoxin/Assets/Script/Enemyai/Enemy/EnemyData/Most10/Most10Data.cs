using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most10Data : LandMost
{
    
    public void Cancel_AinAttack1()
    {
        ani.SetBool("isAttack1", false);

    }

    public void Cancel_AinAttack2()
    {
        ani.SetBool("isAttack2", false);
        Debug.Log("111111");
    }



}
