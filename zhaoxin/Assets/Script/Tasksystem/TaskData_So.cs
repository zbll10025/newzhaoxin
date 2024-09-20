using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TaskData_So")]

public class TaskData_So :ScriptableObject
{
   public List<TaskDetails> TaskDetailsList;
}
