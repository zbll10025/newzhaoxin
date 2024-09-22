using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MostHitParticle : MonoBehaviour
{

    public Sprite[] platformImages;
    public int time;
    public ParticleSystem particleSystems;
    private void Start()
    {
        particleSystems = GetComponent<ParticleSystem>();

    }
    void OnParticleCollision(GameObject other)
    {
        //获取粒子碰撞后的位置信息
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = particleSystems.GetCollisionEvents(other, collisionEvents);
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystems.particleCount];
        particleSystems.GetParticles(particles);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            Vector3 collisionPosition = collisionEvents[i].intersection;
            // 这里没有 index，通常可以通过 collider 来找到相关粒子
            // 比如你可以存储粒子的位置或使用其他方式判断碰撞的粒子

            //根据不同的碰撞体实现不同的碰撞效果素
            if (other.tag == "Platform")
            {
                PlatformEffect(collisionPosition);
            }
            else if (other.tag == "Wall")
            {

            }

        }
      
    }
     public async void PlatformEffect(Vector3 totalPosition)
    {   int indx = Random.Range(0,3);
        Sprite temp = platformImages[indx];
       
        GameObject obj = PoolManger.Instance.Get("BloodEffect", "Prefabs/Enemy/BloodEffect/MostBloodPlatformEffect");
        obj.GetComponent<SpriteRenderer>().sprite = temp;
        obj.transform.position = totalPosition;
        obj.SetActive(true);
        await UniTask.Delay(time);
        PoolManger.Instance.Recycle("BloodEffect", obj);
    }

}
