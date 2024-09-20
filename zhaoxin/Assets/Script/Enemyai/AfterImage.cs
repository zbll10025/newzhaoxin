using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AfterImage : MonoBehaviour
{
    [Header("ÑÕÉ«")]
    public Color color = new Color(0.5f, 0.0f, 0.5f);
    public Color targetColor;
    public float afterImagetime = 0.25f;
    [HideInInspector]
    public string _name;
    public SpriteRenderer spriteRenderer;
    public Sprite currentSprit;

    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();      
        
    }

    private void OnEnable()
    {
                                  
        Color temp = color;
         temp.a = 1f; 
        spriteRenderer.color = temp;
        spriteRenderer.sprite = currentSprit;
        spriteRenderer.DOFade(0, afterImagetime).
             OnStart(ChangeColor)
            .OnComplete(Distory);
    }
    void Distory()
    {
        PoolManger.Instance.Recycle(_name, this.gameObject);
    }
    void ChangeColor()
    {
        spriteRenderer.DOColor(targetColor, afterImagetime);
    }
}
