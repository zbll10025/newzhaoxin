using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MostBulletData 
{
    public string name;
    public string path;
    public bool isRightLocalscal;
    [Header("发射力")]
    public float force;
    [Header("飞行速度")]
    public float speed;
   
}
