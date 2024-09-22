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
        //��ȡ������ײ���λ����Ϣ
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = particleSystems.GetCollisionEvents(other, collisionEvents);
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystems.particleCount];
        particleSystems.GetParticles(particles);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            Vector3 collisionPosition = collisionEvents[i].intersection;
            // ����û�� index��ͨ������ͨ�� collider ���ҵ��������
            // ��������Դ洢���ӵ�λ�û�ʹ��������ʽ�ж���ײ������

            //���ݲ�ͬ����ײ��ʵ�ֲ�ͬ����ײЧ����
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
