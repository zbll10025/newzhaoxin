using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyEnemy :BaseEnemy
{
    [Header("巡逻点")]
    public Transform rupTransform;//右上
    public Transform ldownTransform;//左下
    [Header("飞弹发射位置")]
    public Transform lunchPosiotn;
    [Header("飞弹名字")]
    public string bulletName;
    public MostBulletData mostBullet;
    public bool isaaa;
    Vector3 total;
    public MostBulletLunch mostBulletLunch;

    protected override void Awake()
    {
        base.Awake();
        mostBulletLunch = GetComponent<MostBulletLunch>();
        lunchPosiotn = GameObject.Find("LunchPosition").transform;
        mostBullet = mostBulletLunch.GetBullet(bulletName);
        
    }
    protected override void Update()
    {
        base.Update();
        GetPlayerDistance();
        GetPlayerDirction();

      
    }

    public Vector3 GetRandomPosition()
    {
        float x = Random.Range(ldownTransform.position.x, rupTransform.position.x);
        float y = Random.Range(ldownTransform.position.y, rupTransform.position.y);
        Vector3 a = new Vector3(x, y, 0);
        return a;
    }

    public override void GetPlayerDirction()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { return; }
        Vector2 result = (player.transform.position - transform.position).normalized;
        playerDirection = result;
       
    }

    public override void GetPlayerDistance()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { return; }
        float result = Vector2.Distance(player.transform.position, transform.position);
        playerDistance = result; 
    }

     public void FlyEnemyMove(Vector3 totalPosition,float speed)
    {
        transform.position += (totalPosition - transform.position) * 2 * Time.deltaTime * speed;
    }

    public void UpdataDirc(Vector3 position)
    {
        BaseEnemy landEnemy = this.GetComponent<BaseEnemy>();
        Vector2 dir = (position - transform.position).normalized;

        if (!landEnemy.isRightLocalscal)
        {
            if (-dir.x > 0)
            {
                landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (dir.x > 0)
            {
                landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    public virtual void MostBulletAttack()
    {
        Vector2 dir = playerDirection;

        GameObject bullet = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        bullet.transform.position = lunchPosiotn.position;
        FixDirc();
        mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet);
        if (dir.x < 0)
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bullet.GetComponent<MostBullet>());
        bullet.GetComponent<MostBullet>().OnstartCancelGrivaty();//取消重力
        bullet.SetActive(true);
        bullet.GetComponent<MostBullet>().Onstart_Velocity(dir, mostBullet.speed);
    }

}
