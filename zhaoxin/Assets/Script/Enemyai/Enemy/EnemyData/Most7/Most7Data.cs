using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most7Data : LandMost
{
    [Header("攻击设置")]
    public float scatingForce;
    public float tencleOffeset_y = -5.089f;
    public float spikeOffeset = 0.366f;
    [Header("攻击的偏角")]
    public float scatingOffeset1;
    public float scatingOffeset2;
    Animator Fxani;
    Transform bullet1LunchPosition;
    Transform lunch1Transform;
    Transform lunch2Transform;
    Transform lunch3Transform;
    Transform spik1;
    Transform spik2;
    Transform spik3;
    Transform spik4;
    Transform spik5;
    Transform spik6;
    Transform spik7;
    Vector2 sDir1;
    Vector2 sDir2;
    Vector2 sDir3;
    Vector2 sDir4;
    Vector2 sDir5;
    Vector2 sDir6;
    Vector2 sDir7;


    MostBulletLunch mostBulletLunch;
    MostBulletData mostBullet1Data;
    MostBulletData mostSpikeBulletData;
    protected override void Awake()
    {
        base.Awake();
        attackAlarm = transform.Find("AttackAlarm").transform;
        mostBulletLunch = GetComponent<MostBulletLunch>();
        Fxani = transform.Find("m7DustFX").GetComponent<Animator>();
        #region 获取发射位置
        lunch2Transform = transform.Find("LunchDirc2").transform;
        lunch3Transform =transform.Find("LunchDirc3").transform;
        lunch1Transform = transform.Find("LunchDirc1").transform;
        spik1 = transform.Find("SpikeDirc1").transform;
        spik2 = transform.Find("SpikeDirc2").transform;
        spik3 = transform.Find("SpikeDirc3").transform;
        spik4 = transform.Find("SpikeDirc4").transform;
        spik5 = transform.Find("SpikeDirc5").transform;
        spik6 = transform.Find("SpikeDirc6").transform;
        spik7 = transform.Find("SpikeDirc7").transform;

        bullet1LunchPosition = transform.Find("Bullet1LunchPosition").transform;
        #endregion


        #region 计算方向
        CaculateSpikeDir();
        #endregion
    }
    private void Start()
    {
        mostBullet1Data = mostBulletLunch.GetBullet("Rem7Projectile1");
        mostSpikeBulletData = mostBulletLunch.GetBullet("Rem7Spike");

    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.K))
        {
            ani.SetBool("isRoll",true);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ani.SetBool("isRoll", false);
        }
        if (isDash)
        {
            rig.velocity = new Vector2(dashDir.x * dashSpeed, 0);
        }
    }

    #region 发射三个飞弹
      public void LunchThreeBullet()
    {

        //计算发射方向
        Vector2 dir1 = mostBulletLunch.GetBulletDirc(lunch1Transform);
        Vector2 dir2 = mostBulletLunch.GetBulletDirc(lunch2Transform);
        Vector2 dir3 = mostBulletLunch.GetBulletDirc(lunch3Transform);
        //实例化飞弹
        GameObject obj1= PoolManger.Instance.Get("Rem7Projectile1",mostBullet1Data.path );
        GameObject obj2= PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        GameObject obj3 = PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        //修正飞弹面向
        mostBulletLunch.FixObjectDirc(dir1, mostBullet1Data.isRightLocalscal, obj1);
        mostBulletLunch.FixObjectDirc(dir2, mostBullet1Data.isRightLocalscal, obj2);
        mostBulletLunch.FixObjectDirc(dir3, mostBullet1Data.isRightLocalscal, obj3);
        //初始化发射位置
        obj1.transform.position  =bullet1LunchPosition.position;
        obj2.transform.position = bullet1LunchPosition.position;
        obj3.transform.position = bullet1LunchPosition.position;
        //修正角度
        mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, obj1.GetComponent<MostBullet>());
        mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, obj2.GetComponent<MostBullet>());
        mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, obj3.GetComponent<MostBullet>());
        //激活飞弹
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
        //发射速度
        float force = mostBullet1Data.force;
        obj1.GetComponent<MostBullet>().Onstart_Force(dir1, force);
        obj2.GetComponent<MostBullet>().Onstart_Force(dir2, force);
        obj3.GetComponent<MostBullet>().Onstart_Force(dir3, force);

    }
    #endregion

    #region 向玩家发射一个飞弹
      public void LunchBullet(float speed=0)
    {
        Vector2 dir = this.playerDirection;
        GameObject obj = PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        // mostBulletLunch.FixObjectDirc(dir, mostBullet1Data.isRightLocalscal, obj);
        FixDirc();
        obj.transform.position = bullet1LunchPosition.position;
        MostBullet mostBullet = obj.GetComponent<MostBullet>();
        mostBullet.OnstartCancelGrivaty();
        obj.SetActive(true);
        if (speed == 0)
        {
            speed = mostBullet1Data.speed;
        }
        mostBullet.Onstart_Velocity(dir, speed);
        
    }
    #endregion

    #region 进行刺攻击
    public void SpikeAttack()
    {
        #region 获取物体

        GameObject obj1 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        GameObject obj2 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        GameObject obj3 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        GameObject obj4 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        GameObject obj5 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        GameObject obj6 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        GameObject obj7 = PoolManger.Instance.Get(mostSpikeBulletData.name, mostSpikeBulletData.path);
        #endregion
        #region 改变方向
        CaculateSpikeDir();
        #endregion
        #region 设置位置
        SetPosition(obj1, spik1);
        SetPosition(obj2,spik2) ;
        SetPosition(obj3, spik3) ;
        SetPosition(obj4, spik4) ;
        SetPosition(obj5, spik5) ;
        SetPosition(obj6, spik6) ;
        SetPosition(obj7, spik7) ;


        #endregion
        #region 修正角度偏值
        FixAngle(obj1.GetComponent<MostBullet>());
        FixAngle(obj2.GetComponent<MostBullet>());
        FixAngle(obj3.GetComponent<MostBullet>());
        FixAngle(obj4.GetComponent<MostBullet>());
        FixAngle(obj5.GetComponent<MostBullet>());
        FixAngle(obj6.GetComponent<MostBullet>());
        FixAngle(obj7.GetComponent<MostBullet>());
        #endregion
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
        obj4.SetActive(true);
        obj5 .SetActive(true);
        obj6.SetActive(true);
        obj7.SetActive(true);
        BulletStart(obj1.GetComponent<MostBullet>(), sDir1, 3);
        BulletStart(obj2.GetComponent<MostBullet>(), sDir2, mostSpikeBulletData.force);
        BulletStart(obj3.GetComponent<MostBullet>(), sDir3, mostSpikeBulletData.force);
        BulletStart(obj4.GetComponent<MostBullet>(), sDir4, mostSpikeBulletData.force);
        BulletStart(obj5.GetComponent<MostBullet>(), sDir5, mostSpikeBulletData.force);
        BulletStart(obj6.GetComponent<MostBullet>(), sDir6, mostSpikeBulletData.force);
        BulletStart(obj7.GetComponent<MostBullet>(), sDir7, 3);
    }
    #endregion

    //散弹
    public void ScatingBullet()
    {
        Vector2 dir = (player.transform.position-bullet1LunchPosition.position).normalized;
        float angle1 = scatingOffeset1;
        float angleNeg1 = -scatingOffeset1;
        float angle2 = scatingOffeset2;
        float angleNeg2  = -scatingOffeset2;

        float rad1 = Mathf.Deg2Rad*angle1;
        float radNeg1 = Mathf.Deg2Rad*angleNeg1;
        float rad2 =  Mathf.Deg2Rad*angle2;
        float radNeg2 = Mathf.Deg2Rad*angleNeg2;
        Vector2 dir1 = RotateVector(dir, rad1);
        Vector2 dir1Neg = RotateVector(dir, radNeg1);
        Vector2 dir2 = RotateVector(dir, rad2);
        Vector2 dir2Neg = RotateVector(dir, radNeg2);
        GameObject obj =  PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        GameObject obj1 = PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        GameObject objNeg1 = PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        GameObject obj2 = PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
        GameObject objNeg2 = PoolManger.Instance.Get("Rem7Projectile1", mostBullet1Data.path);
       // mostBulletLunch.FixObjectDirc(dir, mostBullet1Data.isRightLocalscal, obj);
       // mostBulletLunch.FixObjectDirc(dir1, mostBullet1Data.isRightLocalscal, obj1);
       // mostBulletLunch.FixObjectDirc(dir2, mostBullet1Data.isRightLocalscal, obj2);
       // mostBulletLunch.FixObjectDirc(dir1Neg, mostBullet1Data.isRightLocalscal, objNeg1);
       // mostBulletLunch.FixObjectDirc(dir2Neg, mostBullet1Data.isRightLocalscal, objNeg2);
       //mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, obj1.GetComponent<MostBullet>());
       // mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, obj2.GetComponent<MostBullet>());
       // mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, objNeg1.GetComponent<MostBullet>());
       // mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, obj.GetComponent<MostBullet>());
       // mostBulletLunch.FixAngelOffest(mostBullet1Data.isRightLocalscal, objNeg2.GetComponent<MostBullet>());
       obj1.GetComponent<MostBullet>().OnstartCancelGrivaty();
        obj2.GetComponent<MostBullet>().OnstartCancelGrivaty();
        obj.GetComponent<MostBullet>().OnstartCancelGrivaty();
        objNeg1.GetComponent<MostBullet>().OnstartCancelGrivaty();
        objNeg2.GetComponent<MostBullet>().OnstartCancelGrivaty();
        obj1.transform.position = bullet1LunchPosition.position;
        obj2.transform.position = bullet1LunchPosition.position;
        objNeg1.transform.position = bullet1LunchPosition.position;
        obj.transform.position = bullet1LunchPosition.position;
        objNeg2.transform.position = bullet1LunchPosition.position;
        obj.SetActive(true);
        obj1.SetActive(true);
        obj2.SetActive(true);
        objNeg1.SetActive(true);
        objNeg2.SetActive(true);
        float force = scatingForce;
        obj1.GetComponent<MostBullet>().Onstart_Force(dir1, force);
        obj2.GetComponent<MostBullet>().Onstart_Force(dir2, force);
        obj.GetComponent<MostBullet>().Onstart_Force(dir, force);
        objNeg1.GetComponent<MostBullet>().Onstart_Force(dir1Neg, force);
        objNeg2.GetComponent<MostBullet>().Onstart_Force(dir2Neg, force);
       
    }
    public override void CheckAniFallState()
    {
        
        if (isGround)
        {
            ani.SetBool("isFall", true);
        }
    }

    Vector2 GetSpikeDirc(Transform obj)
    {
        Vector3 a = new Vector3(0, spikeOffeset,0);
        return (obj.position - transform.position+a).normalized;
    }
    void BulletStart(MostBullet bullet,Vector2 dir,float force=0)
    {
        bullet.Onstart_Force(dir, force);
    }
    void FixAngle(MostBullet bullet)
    {
        mostBulletLunch.FixAngelOffest(mostSpikeBulletData.isRightLocalscal, bullet);
    }
    void SetPosition(GameObject obj, Transform target)
    {
        obj .transform.position = target.position;
    }
    public Vector2 RotateVector(Vector2 vector, float radians)
    {
        float cosTheta = Mathf.Cos(radians);
        float sinTheta = Mathf.Sin(radians);

        float xNew = vector.x * cosTheta - vector.y * sinTheta;
        float yNew = vector.x * sinTheta + vector.y * cosTheta;

        return new Vector2(xNew, yNew).normalized;
    }
    public void GetTencle()
    {
        GameObject alarm = PoolManger.Instance.Get("AttackAlarm", "Prefabs/Enemy/ReEnemy/Project/AttackAlarm");
         alarm.transform.position = player.transform.position;
         alarm.SetActive(true); 
        GameObject obj = PoolManger.Instance.Get("Rem7Tent", "Prefabs/Enemy/ReEnemy/Project/Rem7Tent");
        obj.transform.position =new Vector3( player.transform.position.x,tencleOffeset_y,0);
        obj.SetActive(true);
    }
    public void Ani_SpikeCancle()
    {
        ani.SetBool("isSpikeAttack", false);
        ani.SetBool("isTired", false);
    }
    public void Fx_AniStart()
    {
         isDash = true; 
        if (!isGround)
        {
            Fxani.SetBool("isRoll", false);
            return;
        }
        if(!Fxani.GetBool("isRoll"))
        Fxani.SetBool("isRoll", true);
    }
    public void Fx_AniAcncle()
    {
        isDash = false;
        Fxani.SetBool("isRoll", false);
    }
    //计算刺攻击方向
    public void CaculateSpikeDir()
    {
        sDir1 = GetSpikeDirc(spik1);
        sDir2 = GetSpikeDirc(spik2);
        sDir3 = GetSpikeDirc(spik3);
        sDir4 = GetSpikeDirc(spik4);
        sDir5 = GetSpikeDirc(spik5);
        sDir6 = GetSpikeDirc(spik6);
        sDir7 = GetSpikeDirc(spik7);
    }
}
