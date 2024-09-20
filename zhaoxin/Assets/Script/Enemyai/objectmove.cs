using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class objectmove : MonoBehaviour
{
    public float end;
    public float time;
    public bool isyuns;
    // Start is called before the first frame update
    void Start()
    {
        if (isyuns)
        {
            transform.DOMoveX(end, time).SetEase(Ease.Linear);
        }
        else {

            transform.DOMoveX(end, time);
        
        }
        
        Debug.Log(DOTween.timeScale);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
