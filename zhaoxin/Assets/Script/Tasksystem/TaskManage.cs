using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TaskManage 
{
    public TaskData_So TaskData_So;
    public CurrentTask_So CurrentTask_So;
    public static TaskManage _instance;
    
    public static TaskManage Instance
    {
        get{

            if (_instance == null)
            {
                _instance = new TaskManage();
               _instance.TaskData_So = Resources.Load<TaskData_So>("So/TaskData_So");
               _instance.CurrentTask_So = Resources.Load<CurrentTask_So>("So/CurrentTask_So");
            }
            return _instance; 
        }

    }

    public bool DelegateTask(string id ,List<TaskDetails> delegateTaskList)
    {
         bool havepreTask=false;
        TaskDetails task = TaskData_So.TaskDetailsList.Find(i => i.id == id);
        if (task == null)
        {
            Debug.Log("总任务表中没有该任务:" + id);
            return false;
        }
        if (task.isper)
        {
            foreach (string preid in task.Pre_task_ID_list)
            {
                if(TaskData_So.TaskDetailsList.Find(i=>i.id == preid).status != TotalStatus.Completed)
                {
                    Debug.Log("任务" + task._name + "的前置任务没完成" + preid+"\n");
                    havepreTask = true;
                }
            }
            if(havepreTask)
            {
                return false;
            }
        }
        
        switch (task.status)
        {
            case TotalStatus.Waitting:
                TaskData_So.TaskDetailsList.Find(i => i.id == id).status = TotalStatus.Acccepted;
                DelegateTaskUpdate(delegateTaskList);

                if (!CurrentTask_So.currentTaskList.Contains(task))
                {
                    CurrentTask_So.currentTaskList.Add(task);
                    TaskManage.Instance.DelegateTaskUpdate(delegateTaskList);
                    return true;
                }
                else
                {
                    Debug.Log("已委派该任务:" + id);
                    return false;
                }

            case TotalStatus.Acccepted:
                Debug.Log("已委派该任务:" + id);
                return false;
            case TotalStatus.Completed:
                Debug.Log("已完成该任务:" + id);
                return false;
            case TotalStatus.Failed:
                Debug.Log("任务已失败");
                return false;
            default:
                Debug.Log("未知任务状态:" + task.status);
                return false;
        }
    }

    public void TaskFnish(string id)
    {
        TaskDetails thistask = TaskData_So.TaskDetailsList.Find(i => i.id == id);
        TaskDetails currenttask =CurrentTask_So.currentTaskList.Find(i=>i.id == id);
        if(thistask == null) 
        {
            Debug.Log("总任务表中没有该任务：" + id);
            return; 
        }
        if(currenttask == null)
        {
            Debug.Log(" 玩家当前任务表中没有该任务：" + id);
            return;
        }
        if (thistask.status != TotalStatus.Acccepted)
        {
            Debug.Log(thistask._name+"任务不处于执行状态,该任务住状态为："+thistask.status);
            return;
        }

        thistask.status = TotalStatus.Completed;
        CurrentTaskUpdata();
    }
    public void TaskFailed(string id)
    {
        TaskDetails thistask = TaskData_So.TaskDetailsList.Find(i => i.id == id);
        TaskDetails currenttask = CurrentTask_So.currentTaskList.Find(i => i.id == id);
        if (thistask == null)
        {
            Debug.Log("总任务表中没有该任务：" + id);
            return;
        }
        if (currenttask == null)
        {
            Debug.Log("当前任务表中没有该任务：" + id);
            return;
        }
        if (thistask.status != TotalStatus.Acccepted)
        {
            Debug.Log(thistask._name + ",任务不处于执行状态,该任务住状态为：" + thistask.status);
            return;
        }
        //错误检测
        thistask.status = TotalStatus.Failed;
        currenttask.status = TotalStatus.Failed;
        //其他
    }
    public void CurrentTaskUpdata()
    {
        CurrentTask_So.currentTaskList = new List<TaskDetails>();
        foreach (TaskDetails taskData in TaskData_So.TaskDetailsList)
        {
            if (taskData.status != TotalStatus.Waitting) { CurrentTask_So.currentTaskList.Add(taskData);
        }
        }    
    }
    public void  DelegateTaskUpdate(List<TaskDetails> delegateTask)
    {
       foreach (TaskDetails delegatetaskData in delegateTask)
        {
           TaskManage.Instance.TaskCopy( delegatetaskData , TaskData_So.TaskDetailsList.Find(i=>i.id == delegatetaskData.id));
        }
    }
    public void TaskCopy(TaskDetails a, TaskDetails b)
    {
        a.description = b.description;
        a.status = b.status;
        a.taskImage = b.taskImage;
        a.Type = b.Type;
        a.isper = b.isper;
        a._name = b._name;
        a.money = b.money;
        a.isreach = b.isreach;
        a.istalk = b.istalk;
        a.goalcount = b.goalcount;
        a.getcount = b.getcount;
        a.Pre_task_ID_list = new List<string>();
        foreach (string i in b.Pre_task_ID_list)
        {
            a.Pre_task_ID_list.Add(i);
        }
    }
}

