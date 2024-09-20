using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most11Data : FlyEnemy
{
    [Header("����ɵ�֮��ĽǶ�")]
    public float offset = 0.2f;

    public override void MostBulletAttack()
    {
        
        //��ȡ���䷽��
        Vector2 dir = playerDirection;
        GameObject bullet1 = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        GameObject bullet2 = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        GameObject bullet3 = PoolManger.Instance.Get(mostBullet.name, mostBullet.path);
        //���·ɵ�λ��
        bullet1.transform.position = lunchPosiotn.position;
        bullet2.transform.position = lunchPosiotn.position;
        bullet3.transform.position = lunchPosiotn.position;
        //���������������
        FixDirc();
        
        //��ȡ�ɵ������MostBullet
        MostBullet bu1 = bullet1.GetComponent<MostBullet>();
        MostBullet bu2 = bullet2.GetComponent<MostBullet>();
        MostBullet bu3 = bullet3.GetComponent<MostBullet>();
        //���·ɵ�����
            mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet1);
            mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet2);
            mostBulletLunch.FixObjectDirc(dir, mostBullet.isRightLocalscal, bullet3);
        //���Ǹ���ʵ�����еĵ���
        if ( dir.x< 0)
        {   //������ת�Ƕȵ�����ֵ

            
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bu1);
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bu2);
            mostBulletLunch.FixAngelOffest(mostBullet.isRightLocalscal, bu3);
        }
       
        
       //ȡ������,���������¼�
        bu1.OnstartCancelGrivaty();
        bu2.OnstartCancelGrivaty();
        bu3.OnstartCancelGrivaty();
        #region �������ڷɵ��ķ���
        //��ת�Ƕ�
        float angle = offset;
        float angleNeg = -offset;

        // ���Ƕ�ת��Ϊ����
        float rad = Mathf.Deg2Rad * angle;
        float radNeg = Mathf.Deg2Rad * angleNeg;

        // ������ת�������
        Vector2 dir1 = RotateVector(dir, rad);
        Vector2 dir2 = RotateVector(dir, radNeg);
        #endregion


        //����
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
