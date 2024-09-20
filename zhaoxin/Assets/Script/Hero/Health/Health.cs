using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Animator[] healthItem;
    public Animator geo;
    
    private void Hit()
    {
        healthItem[0].SetTrigger("Enter");
    }
    public IEnumerator ShowHealthItems()
    {
        for (int i = 0; i < healthItem.Length; i++) 
        {
            healthItem[i].SetTrigger("Enter");
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.2f);
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
