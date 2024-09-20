using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachCheck : MonoBehaviour
{
    public bool isApporach;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            isApporach = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isApporach = false;
        }

    }
}
