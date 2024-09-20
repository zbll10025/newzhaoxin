using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
public class Most5Attack : MonoBehaviour{


    public Transform playerTransform;
    public Most5Data most5Data;
    public GameObject fly;
    public Vector3 offeset;
    public float force;
    private void Awake()
    {
        most5Data = GetComponent<Most5Data>();
        offeset = new Vector3(0, 0.1f, 0);
    }


    public void isStartAttack()
    {
        Mostdir();
        if(playerTransform==null)
        playerTransform  = most5Data.player.GetComponent<Transform>();
        //fly= GameObject.Instantiate(Resources.Load("ReEnemy/Project/Rem5Projectile"), transform.position+offeset,Quaternion.identity)as GameObject;
        fly = PoolManger.Instance.Get("Rem5Projectile", "Prefabs/Enemy/ReEnemy/Project/Rem5Projectile");
        fly.transform.position = transform.position+offeset;
        fly.SetActive(true);

        fly.transform.localScale =new Vector3(most5Data.gameObject.transform.localScale.x,1,1) ;
        Vector2 dirc = (most5Data.player.transform.position+offeset - fly.transform.position).normalized;
        float angel = Mathf.Atan2(dirc.y,dirc.x)*Mathf.Rad2Deg;
        fly.transform.eulerAngles = new Vector3(0,0,angel);

        Rigidbody2D flyRig = fly.GetComponent<Rigidbody2D>();
        flyRig.AddForce(dirc*force, ForceMode2D.Impulse);
        
    }
    public void Mostdir()
    {
        if (-most5Data.playerDirection.x > 0)
        {
            most5Data.transform.localScale = new Vector2(1, 1);
        }
        else if(-most5Data.playerDirection.x < 0)
        {
            most5Data.transform.localScale = new Vector2(-1, 1);
        }
    }

}
