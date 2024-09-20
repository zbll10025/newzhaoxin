using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most14Data : LandMost {
    
    [Header("∑¢…‰Œª÷√")]
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    [Header("∑…µØ")]
    public string bulletName;
    public Vector3 offset;
    public MostBulletLunch mostBulletLunch;
    public MostBulletData mostbullet;

    Vector2 dir1;
    Vector2 dir2;
    Vector2 dir3;
    Vector2 dir4;
    Vector2 dir5;
    Vector2 dir6;
    protected override void Awake()
    {
        base.Awake();
        pos1 = transform.Find("LunchPosition1").transform;
        pos2 = transform.Find("LunchPosition2").transform;
        pos3 = transform.Find("LunchPosition3").transform;
        pos4 = transform.Find("LunchPosition4").transform;
        pos5 = transform.Find("LunchPosition5").transform;
        pos6 = transform.Find("LunchPosition6").transform;
        mostBulletLunch  = GetComponent<MostBulletLunch>();
        mostbullet = mostBulletLunch.GetBullet(bulletName);
    }

    public void BulletAttack()
    {
        //Vector2 dir = new Vector2(0,1);
        CaculateDir();
        GameObject bullet1= PoolManger.Instance.Get(mostbullet.name, mostbullet.path);
        GameObject bullet2 = PoolManger.Instance.Get(mostbullet.name, mostbullet.path);
        GameObject bullet3 = PoolManger.Instance.Get(mostbullet.name, mostbullet.path);
        GameObject bullet4 = PoolManger.Instance.Get(mostbullet.name, mostbullet.path);
        GameObject bullet5 = PoolManger.Instance.Get(mostbullet.name, mostbullet.path);
        GameObject bullet6 = PoolManger.Instance.Get(mostbullet.name, mostbullet.path);

        bullet1.transform.position = pos1.position;
        bullet2.transform.position = pos2.position;
        bullet3.transform.position = pos3.position;
        bullet4.transform.position = pos4.position;
        bullet5.transform.position = pos5.position;
        bullet6.transform.position = pos6.position;

        bullet1.SetActive(true);
        bullet2.SetActive(true);
        bullet3.SetActive(true);
        bullet4.SetActive(true);
        bullet5.SetActive(true);
        bullet6.SetActive(true);


        BulletOnstart(dir1, bullet1);
        BulletOnstart(dir2, bullet2);
        BulletOnstart(dir3, bullet3);
        BulletOnstart(dir4, bullet4);
        BulletOnstart(dir5, bullet5);
        BulletOnstart(dir6, bullet6);
    }

    public void BulletOnstart(Vector2 dir,GameObject bullet)
    {
        bullet.GetComponent<MostBullet>().Onstart_Velocity(dir, mostbullet.speed);
    }
    public void CaculateDir()
    {
        dir1 = (pos1.transform.position - transform.position+offset);
        dir2 = (pos2.transform.position - transform.position+offset);
        dir3 = (pos3.transform.position - transform.position + offset);
        dir4 = (pos4.transform.position - transform.position + offset);
        dir5 = (pos5.transform.position - transform.position + offset);
        dir6 = (pos6.transform.position - transform.position + offset);

    }
}
