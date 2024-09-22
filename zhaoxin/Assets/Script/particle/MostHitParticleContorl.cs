using BehaviorDesigner.Runtime.Tasks.Unity.UnityParticleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.Rendering.DebugUI;

public class MostHitParticleContorl : MonoBehaviour
{
    public ParticleSystem afterUpSystem;
    public ParticleSystem afterDownSystem;
    public ParticleSystem beforeSystem;
    [Header("角速度")]
    public float aUOrgion;
    public float aDOrgion;
    public float beOrgion;
    [Header("初始角度")]
    public float upStart;
    public float downStart;
    public float beforceStart;
    [Header("在代码内赋值")]
   public bool isRig;
    public Transform most;
    RotationBySpeedModule rotationAU;
    RotationBySpeedModule rotaitionAD;
    RotationBySpeedModule rotationBefore;
    MainModule mainAu;
    MainModule mainAD;
    MainModule mainBeforce;
    private void Start()
    {
        
         OnStart();
        
    }
    //需要赋值 isRig,most
    public void OnStart()
    {
             rotationAU = afterUpSystem.rotationBySpeed;
             rotaitionAD = afterDownSystem.rotationBySpeed;
             rotationBefore = beforeSystem.rotationBySpeed;
                 mainAu = afterUpSystem.main;
                 mainAD = afterDownSystem.main;
                 mainBeforce = beforeSystem.main;
            ChangeAngleRotation(isRig, most.localScale.x);
    }
    #region 角速度的修改
    public void  ChangeAngleRotation(bool isRight,float x)
    {
        if (!isRight)
        {
            if (x < 0)
            {
                ChangeAngles(true);
                ChangeStartRotation();
            }
        }
        else
        {
            if (x > 0)
            {
                ChangeAngles(true);
                ChangeStartRotation();
            }
        }
    }
    public void ChangeAngles(bool isChange)
    {
        if (isChange) {
            ChangeAngle(rotationAU, -aUOrgion);
            ChangeAngle(rotaitionAD, -aDOrgion);
            ChangeAngle(rotationBefore,-beOrgion);
        
        }
    }

  
    public void ChangeAngle(RotationBySpeedModule rotation,float value)
    {
        rotation.z = new ParticleSystem.MinMaxCurve(value / Mathf.Rad2Deg);
    }
    #endregion

    //修改粒子初始化的角度
    public void ChangeStartRotation()
    {
         mainAu.startRotation = new ParticleSystem.MinMaxCurve(-upStart / Mathf.Rad2Deg);
        mainAD.startRotation = new ParticleSystem.MinMaxCurve(-downStart / Mathf.Rad2Deg);
        mainBeforce.startRotation = new ParticleSystem.MinMaxCurve(-beforceStart / Mathf.Rad2Deg);
    }
    public void Clear()
    {
        ChangeAngle(rotationAU, aUOrgion);
        ChangeAngle(rotaitionAD, aDOrgion);
        ChangeAngle(rotationBefore, beOrgion);
        mainAu.startRotation = new ParticleSystem.MinMaxCurve(upStart / Mathf.Rad2Deg);
        mainAD.startRotation = new ParticleSystem.MinMaxCurve(downStart / Mathf.Rad2Deg);
        mainBeforce.startRotation = new ParticleSystem.MinMaxCurve(beforceStart / Mathf.Rad2Deg);
    }
}
