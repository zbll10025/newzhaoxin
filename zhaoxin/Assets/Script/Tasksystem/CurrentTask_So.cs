using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CurrentTask")]
[System.Serializable]
public class CurrentTask_So : ScriptableObject
    {

    private void Awake()
    {
       
    }
    public List<TaskDetails> currentTaskList;
    }
