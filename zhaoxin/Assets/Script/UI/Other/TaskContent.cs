using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Script.Tasksystem;
using BehaviorDesigner.Runtime.Tasks;
public class TaskContent : MonoBehaviour
{
    public TextMeshProUGUI taskDescribe;
    public TextMeshProUGUI gatheringDescrible;
    public TextMeshProUGUI reachDescrible;
    public TextMeshProUGUI talkDescrible;
    public TaskDetails taskDetails;
    public string discrible;
    public TotalStatus status;
    public TaskType type;
    
   public void DiscribleShow()
    {

       //显示该数据前先清空描述内容
        Clear();
       //显示基本数据
        taskDescribe.text = taskDetails.description;
       //根据任务类型显示
        switch (type)
        {
            case TaskType.Gathering:

                gatheringDescrible.text =   taskDetails.getcount.ToString() + "/"+taskDetails.goalcount.ToString();
                break;
            case TaskType.Reach:
                if (taskDetails.isreach)
                {
                    reachDescrible.text = "已到达";
                }
                else
                {
                    reachDescrible.text = "未到达";
                }
                break;
            case TaskType.Talk:
                if (taskDetails.istalk)
                {
                    talkDescrible.text = "已交谈";
                }
                else
                {
                    talkDescrible.text = "未交谈";
                }
                break;
        }
    }

    public void Clear()
    {
        if (taskDescribe != null)
            taskDescribe.text = "";

        if (gatheringDescrible != null)
            gatheringDescrible.text = "";

        if(reachDescrible!=null)
            reachDescrible.text = "";

        if(talkDescrible!=null)
            talkDescrible.text = "";

    }
}
