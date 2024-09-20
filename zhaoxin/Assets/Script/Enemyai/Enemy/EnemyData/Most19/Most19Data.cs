using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most19Data : LandMost
{
    [Header("状态")]
     public bool isHide;
    public float afterImageTime = 0.1f;
    protected override void Awake()
    {
        base.Awake();
        PoolManger.Instance.CreatPool("Most19AfterImage", "Prefabs/Enemy/AfterImage", 50);
    }
    
    protected override void Update()
    {
        base.Update();
        if (isDash)
        {
            
                Most19AfterImage();
            
           
        }
        
    }
    public override void Onhit()
    {
        base.Onhit();
        isHide = true;
    }

    public void Cancel_AinisHide()
    {
        ani.SetBool("isHide",false);
    }

    public void Most19AfterImage()
    {
        GameObject afterImage = PoolManger.Instance.Get("Most19AfterImage", "Prefabs/Enemy/AfterImage");
        if (afterImage == null) { Debug.Log("object为空"); return; }
        AfterImage objcomp = afterImage.GetComponent<AfterImage>();
        objcomp._name = "Most19AfterImage";
        objcomp.afterImagetime = afterImageTime;
        objcomp.currentSprit = spriteRenderer.sprite;
        objcomp.transform.position = transform.position;
        objcomp.transform.localScale = transform.localScale;
        objcomp.gameObject.SetActive(true);
    }
}
