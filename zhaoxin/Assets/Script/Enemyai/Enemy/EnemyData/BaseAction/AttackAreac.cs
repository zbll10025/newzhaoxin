using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreac : MonoBehaviour
{
    public bool isattackarea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isattackarea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isattackarea = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isattackarea = true;
        }
    }
}
