using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class MostBulletLunch : MonoBehaviour
{
    public MostBullet_SO mostBullet_SO;
    public BaseEnemy most;
    public Transform lunchTransform;
    public Vector2 lunchDirc;

    public float offset = 180;
    protected virtual void Awake()
    {
        mostBullet_SO = Resources.Load<MostBullet_SO>("So/MostBullet_So");
       most= GetComponent<BaseEnemy>();
    }
    public MostBulletData GetBullet(string bulletName)
    {
        mostBullet_SO = Resources.Load<MostBullet_SO>("So/MostBullet_So");
        MostBulletData bullet = mostBullet_SO.List_MostBullet.Find(i => i.name == bulletName);
        return bullet;
    }

    public Vector2 GetBulletDirc(Transform transform)
    {
        Vector2 var = new Vector2(transform.position.x - this.gameObject.transform.position.x, transform.position.y - this.gameObject.transform.position.y).normalized;
        return  var;    
    }

    public void FixObjectDirc(Vector2 _lunchDirc,bool isRghtLocalscale ,GameObject obj)
    {
        if (!isRghtLocalscale)
        {
            if (-_lunchDirc.x > 0)
            {
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                obj.transform.localScale  =new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (_lunchDirc.x > 0)
            {
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                obj.transform.localScale = new Vector3(-1, 1, 1);
            }

        }
    }

    public void FixAngelOffest(bool isRhitLocalscale, MostBullet bullet)
    {
        if (isRhitLocalscale)
        {
            if (!most.isRightLocalscal)
            {
                if (most.transform.localScale.x < 0)
                {
                    bullet.angelOffest = 0;
                }
                else
                {
                    bullet.angelOffest =offset;
                }

            }

        }
        else
        {
           
            if (!most.isRightLocalscal)
            {
                if (most.transform.localScale.x > 0)
                {
                   
                    bullet.angelOffest = offset;
                }
                else
                {
                    bullet.angelOffest = 0;
                }

            }
        }
    }
}
