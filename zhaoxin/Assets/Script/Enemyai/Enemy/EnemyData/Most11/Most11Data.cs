using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most11Data : FlyEnemy
{
    [Header("怪物飞弹之间的角度")]
    public float offset = 0.2f;

    public override void MostBulletAttack()
    {
        
        //获取发射方向
        Vector2 dir = playerDirection;
        GameObject bullet1 = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        GameObject bullet2 = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        GameObject bullet3 = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        //更新飞弹位置
        bullet1.transform.position = lunchPosiotn.position;
        bullet2.transform.position = lunchPosiotn.position;
        bullet3.transform.position = lunchPosiotn.position;
        //修正怪物面向玩家
        FixDirc();
        
        //获取飞弹物体的MostBullet
        MostBullet bu1 = bullet1.GetComponent<MostBullet>();
        MostBullet bu2 = bullet2.GetComponent<MostBullet>();
        MostBullet bu3 = bullet3.GetComponent<MostBullet>();
        //更新飞弹方向
            mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet1);
            mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet2);
            mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet3);
        //这是更具实际运行的调整
        if ( dir.x< 0)
        {   //物体旋转角度的修正值

            
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bu1);
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bu2);
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bu3);
        }
       
        
       //取消重力,函数里是事件
        bu1.OnstartCancelGrivaty();
        bu2.OnstartCancelGrivaty();
        bu3.OnstartCancelGrivaty();
        #region 计算相邻飞弹的方向
        //旋转角度
        float angle = offset;
        float angleNeg = -offset;

        // 将角度转换为弧度
        float rad = Mathf.Deg2Rad * angle;
        float radNeg = Mathf.Deg2Rad * angleNeg;

        // 计算旋转后的向量
        Vector2 dir1 = RotateVector(dir, rad);
        Vector2 dir2 = RotateVector(dir, radNeg);
        #endregion


        //激活
        bullet1.SetActive(true);
        bullet2.SetActive(true);
        bullet3.SetActive(true);
        
        bu1.Onstart_Velocity(dir, mostBullet.speed);
        bu2.Onstart_Velocity(dir1, mostBullet.speed);
        bu3.Onstart_Velocity(dir2, mostBullet.speed);
    }

   public Vector2 RotateVector(Vector2 vector, float radians)
    {
        float cosTheta = Mathf.Cos(radians);
        float sinTheta = Mathf.Sin(radians);

        float xNew = vector.x * cosTheta - vector.y * sinTheta;
        float yNew = vector.x * sinTheta + vector.y * cosTheta;

        return new Vector2(xNew, yNew);
    }
}
