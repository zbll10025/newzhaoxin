using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TaskTarget : MonoBehaviour
{
    public string id;
    public TaskType type;
    TaskData_So TaskData_SO;
    private void Awake()
    {
        TaskData_SO = Resources.Load<TaskData_So>("So/TaskData_So");
    }
    public void TaskFinsh()
    {
        TaskDetails thisTask = TaskData_SO.TaskDetailsList.Find(i => i.id == this.id);

            if (thisTask == null)
            {
                Debug.Log("总任务表没有该收任务" + id);
                return;
            }
            if (thisTask.status!=TotalStatus.Acccepted) {
            return;
        }
            if (thisTask.Type!=type) {
            Debug.Log("target与任务总表中的任务类型不匹对");
            return;
              }
          switch (type) {
           case TaskType.Gathering:
                thisTask.getcount++;
            if (thisTask.getcount >= thisTask.goalcount)
            {
                    TaskManage.Instance.TaskFnish(id);
            }
           break;
            case TaskType.Reach:
                thisTask.isreach = true;
                TaskManage.Instance.TaskFnish(id);
                break;
            case TaskType.Talk:
                thisTask.istalk = true;
                TaskManage.Instance.TaskFnish(id);
                break;
        }


       
    }
    public void TaskFailed()
    {
        //
    }
}

//[CustomEditor(typeof(TaskTarget))]
//public class TasktargetEditor:Editor{ 


//}

