using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.VersionControl;
using System.Linq;

namespace Assets.Script.Tasksystem
{

    public class DelegateTaskable : MonoBehaviour
    {
         [SerializeField]
        public List<TaskDetails> delegateTaskList;
        public TaskData_So TaskData_S0;
        public CurrentTask_So CurrentTask_So;
        public bool canDelegate;
        private void Awake()
        {
            TaskData_S0 = Resources.Load<TaskData_So>("So/TaskData_So");
            CurrentTask_So = Resources.Load<CurrentTask_So>("So/CurrentTask_So");
            if (TaskData_S0 == null)
            {
                Debug.Log("没有找到总文件表");
            }

            foreach (TaskDetails delegateTask in delegateTaskList)
            {
                if (delegateTask.id == "")
                {
                    Debug.Log("要委派的任务没有id");
                    return;
                }

                TaskDetails Task = TaskData_S0.TaskDetailsList.Find(i => i.id == delegateTask.id);
                if (Task == null)
                {
                    TaskData_S0.TaskDetailsList.Add(delegateTask);
                }
                else
                {
                    TaskManage.Instance.TaskCopy(delegateTask, Task);
                }

            }
        }
       

        private void OnTriggerEnter2D(Collider2D collision)
        {
           if (collision.CompareTag("Player"))
            {
                canDelegate = true;
                TaskManage.Instance.DelegateTaskUpdate(delegateTaskList);
                TaskManage.Instance.CurrentTaskUpdata();
                
            }
           
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            canDelegate = false;
            TaskManage.Instance.CurrentTaskUpdata();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                TaskManage.Instance.DelegateTask("01", delegateTaskList);
                TaskManage.Instance.DelegateTask("02", delegateTaskList);
            }
        }


        //自定义更新总列表功能
        public void TaskData_SoUpdate()
        {
            TaskData_S0 = Resources.Load<TaskData_So>("So/TaskData_So");
            CurrentTask_So = Resources.Load<CurrentTask_So>("So/CurrentTask_So");

            foreach (TaskDetails delegateTask in delegateTaskList)
            {
                if (delegateTask.id == "")
                {
                    Debug.Log("更新的任务没有id:"+delegateTask._name);
                    return;
                }

                TaskDetails Task = TaskData_S0.TaskDetailsList.Find(i => i.id == delegateTask.id);
                if (TaskData_S0.TaskDetailsList.Find(i => i.id == delegateTask.id)==null)
                {
                    TaskData_S0.TaskDetailsList.Add(delegateTask);
                }
                else
                {
                   
                    if (Task._name != delegateTask._name)
                    {
                        Debug.Log("任务"+delegateTask._name+"与任务"+Task._name+"id重合,id为"+Task.id);
                        return;
                    }
                    TaskManage.Instance.TaskCopy(Task,delegateTask);
                }

            }

        }

    }

}