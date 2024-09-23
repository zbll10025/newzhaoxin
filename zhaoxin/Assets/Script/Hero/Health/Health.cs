using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Animator[] healthItem;
    public Animator geo;

    private Hero player;
    private void Start()
    {
        player = FindObjectOfType<Hero>();
    }
    public void Hit()
    {
        if(PlayerState.isDead) return;
        if (player.health > 5) return;
        healthItem[player.health-1].SetTrigger("Hit");
    }
    public void SetHealthUI()
    {
        for(int i = player.health; i < healthItem.Length; i++)
        {
            healthItem[i].SetTrigger("Hit");
        }
    }
    public IEnumerator ShowHealthItems()
    {
        for (int i = 0; i < healthItem.Length; i++) 
        {
            healthItem[i].SetTrigger("Enter");
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.2f);
        SetHealthUI();
        geo.Play("Enter");
    }
    public void HidHealthItem()
    {
        geo.Play("Exit");
        for(int i = 0;i < healthItem.Length;i++) 
        {
            healthItem[i].SetTrigger("Exit");
        }
    }
}
