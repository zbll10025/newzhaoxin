using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most6Attack :MonoBehaviour
{
    public Most6Data most6Data;
    public GameObject lunchDirection;
    public Vector2 dirce;
    public Vector3 lunchAngel;
    public float force;
    private void Awake()
    {
        most6Data = GetComponent<Most6Data>();
        Transform mostTransform = most6Data.GetComponent<Transform>();
        lunchDirection = most6Data.gameObject.transform.Find("LaunchDirection").gameObject;
        Vector2 dirc = (lunchDirection.transform.position - mostTransform.transform.position).normalized;
        dirce = dirc;
        float angel = Mathf.Atan2(dirc.y, dirc.x) * Mathf.Rad2Deg;
        lunchAngel = new Vector3(0, 0, angel);
    }
   
}
