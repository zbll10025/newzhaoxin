using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soul : MonoBehaviour
{
    Hero player;
    int maxSoul = 5;
    int minSoul = 0;
    Animator soulAnim;
    public Sprite[] soulSprite;
    public Image soulImage;
    private void Start()
    {
        soulImage = GameObject.Find("SoulOrb").GetComponentInChildren<Image>();

        player = transform.parent.GetComponent<Hero>();
       
        soulAnim = GameObject.Find("SoulOrb").GetComponent<Animator>();
        TimerManager.MainInstance.GetTimer(0.5f, DisableAnimator);
    }
    private void Update()
    {
        
        soulImage.sprite = soulSprite[player.soulOrbIndex];
    }
    public void DisableAnimator()
    {
        soulAnim.enabled = false;  // 禁用 Animator，检查是否是 Animator 覆盖了脚本设置
        soulImage.gameObject.SetActive(true);
    }
}
