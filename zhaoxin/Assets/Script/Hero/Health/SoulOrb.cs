using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulOrb : MonoBehaviour
{
    private Health health;
    public Animator soulOrb;
    private void Awake()
    {
        health = FindObjectOfType<Health>();
        soulOrb = GetComponent<Animator>();
    }
    public void DelayShowOrb()
    {
        soulOrb.SetTrigger("Enter");
        soulOrb.Play("Enter");
        //StartCoroutine(ShowOrb());
    }
    //IEnumerator ShowOrb()
    //{
    //    yield return new WaitForSeconds();
    //    soulOrb.SetTrigger("Enter");
    //}
    public void HidOrb()
    {
        soulOrb.SetTrigger("Exit");
    }
    public void ShowHealthItems()
    {
        StartCoroutine(health.ShowHealthItems());
    }
    public void HideHealthItems()
    {
        health.HidHealthItem();
    }
}
