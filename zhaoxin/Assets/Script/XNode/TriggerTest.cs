using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public TaskTarget task;
    private void Awake()
    {
        task = GetComponent<TaskTarget>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            task.TaskFinsh();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(this.gameObject,0.1f);
    }
}
