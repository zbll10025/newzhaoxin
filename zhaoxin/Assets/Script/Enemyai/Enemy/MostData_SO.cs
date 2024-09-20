using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MostData 
{
    public int Id;
    public float hp;
    public float potralSpeed;
    public float rushSpeed;
    public float dashforce;
    public float hitforce;
    

}


[CreateAssetMenu(fileName =("MostData_SO"))]
[System.Serializable]
public class MostData_SO : ScriptableObject
{
  
  public  List<MostData> mostdataList;
  public void Initialize(BaseEnemy enemy)
    {
        MostData most = mostdataList.Find(i => i.Id == enemy.Id);
        if (most == null)
        {
            Debug.Log("配置表不存在该怪物id" + enemy);
            return;
        }
        enemy.Id = most.Id;
        enemy.hp = most.hp;
        enemy.patorlSpeed = most.potralSpeed;
        enemy.rushSpeed = most.rushSpeed;
        enemy.dashForce = most.dashforce;
        enemy.hitForce = most.hitforce;
    }

}
