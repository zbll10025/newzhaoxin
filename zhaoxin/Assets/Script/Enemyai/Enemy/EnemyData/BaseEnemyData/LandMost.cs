using BehaviorDesigner.Runtime;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;
using Cysharp.Threading.Tasks;



public class LandMost : BaseEnemy
    {
   
       //前十个地面怪物检测player组件的方法在各自的子类里
        public BehaviorTree behaviorTree;

        protected override void Awake()
        {
           base.Awake();
           player = GameObject.Find("Player");
          

        }  
        // Update is called once per frame
        protected override void Update()
        {
             base.Update();
            GetPlayerObject();
            GetPlayerDirction();
            GetPlayerDistance();
        }

    public virtual void CancelAniAttack()
    {
        
        ani.SetBool("isAttack", false);
    }
}
