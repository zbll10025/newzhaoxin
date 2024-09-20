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

       //��ʾ������ǰ�������������
        Clear();
       //��ʾ��������
        taskDescribe.text = taskDetails.description;
       //��������������ʾ
        switch (type)
        {
            case TaskType.Gathering:

                gatheringDescrible.text =   taskDetails.getcount.ToString() + "/"+taskDetails.goalcount.ToString();
                break;
            case TaskType.Reach:
                if (taskDetails.isreach)
                {
                    reachDescrible.text = "�ѵ���";
                }
                else
                {
                    reachDescrible.text = "δ����";
                }
                break;
            case TaskType.Talk:
                if (taskDetails.istalk)
                {
                    talkDescrible.text = "�ѽ�̸";
                }
                else
                {
                    talkDescrible.text = "δ��̸";
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
