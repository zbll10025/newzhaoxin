using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most6Data : LandMost
{
    public PlayerCheck PlayerCheck;
    public GameObject BAttack;
    public PlayerCheck PlayerApporach;
   public Most6Type Most6Type;

    protected override void Awake()
    {
        base.Awake();
        PlayerCheck= transform.Find("PlayerCheck").gameObject.GetComponent<PlayerCheck>();
        BAttack = transform.Find("BAttackLunch").gameObject;
        if (Most6Type == Most6Type.B)
        {
          PlayerApporach = transform.Find("PlayerApproachCheck").gameObject.GetComponent<PlayerCheck>();
        }
        
    }
}
 public  enum Most6Type {A,B}
