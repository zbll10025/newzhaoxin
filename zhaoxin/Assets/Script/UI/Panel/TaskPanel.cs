using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel :BasePanel
{
    [Header("显示描述（需要挂载）")]
    public GameObject describleAcrea;
    public TextMeshProUGUI gatheringDescrible;
    public TextMeshProUGUI reachDescrible;
    public TextMeshProUGUI talkDescrible;
    public TaskData_So TaskData_So;
    [Header("测试数据")]
    public GameObject content;//方便挂载子物体
    public GameObject rcycleContent;//方便pool池的回收不影响ui显示
    public RectTransform contentRecttrasform;
    public string path = "Prefabs/Scene/Task";
    public List<GameObject> taskCotentObjList = new List<GameObject>(); 
    public void Awake()
    {
        describleAcrea.GetComponent<TextMeshProUGUI>().text = "";
        gatheringDescrible.text = "";
        reachDescrible.text = "";
        talkDescrible.text = "";
    }

    public void UpdataCompeletUI()
    {
        ClearTaskCotent();
        ClearDescrible();
        foreach (TaskDetails i in TaskData_So.TaskDetailsList)
        {
            if(i.status==TotalStatus.Completed)
              LoadPrefabs(i);
        }
    }
    public void UpdataAllUI()
    {
        ClearTaskCotent();
        ClearDescrible();
        foreach (TaskDetails i in TaskData_So.TaskDetailsList)
        {
           
                LoadPrefabs(i);
        }
    }
    public void UpdataAcceptUI()
    {
        ClearTaskCotent();
        ClearDescrible();
        foreach (TaskDetails i in TaskData_So.TaskDetailsList)
        {
            if (i.status == TotalStatus.Acccepted)
                LoadPrefabs(i);
        }
    }
    public void LoadPrefabs(TaskDetails data)
    {
    
        GameObject obj =PoolManger.Instance.Get("TaskCotent",path);//加载TaskButton
        obj.GetComponent<RectTransform>().SetParent(contentRecttrasform);//设置父物体
        taskCotentObjList.Add(obj);//加入列表方便管理
        TaskContent taskContent = obj.GetComponent<TaskContent>();//获取滑动条内的task的组件

        ////传入数据
        taskContent.taskDetails = data;//将数据传入对应的BUtton
        taskContent.status =  data.status;
        taskContent.type = data.Type;
        taskContent.taskDescribe = describleAcrea.GetComponent<TextMeshProUGUI>();//传入UI描述任务的组件
        taskContent.reachDescrible = reachDescrible;
        taskContent.gatheringDescrible = gatheringDescrible;
        taskContent.talkDescrible = talkDescrible;
        ////

        Button button = obj.GetComponent<RectTransform>().Find("Button").GetComponent<Button>();
        TextMeshProUGUI buttonMesh = obj.GetComponent<RectTransform>().Find("Button").GetComponent<RectTransform>().Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        buttonMesh.text = data._name;
        obj.SetActive(true);
        //绑定按钮事件，赋值
       
        //button.onClick.AddListener(Show);
    }
    public void Show()
    {

    }

    public void ClearTaskCotent()
    {
        //通过tco列表清理滑动条中的子物体
        foreach(GameObject i in taskCotentObjList)
        {
            PoolManger.Instance.Recycle("TaskCotent", i);
            i.GetComponent<RectTransform>().SetParent(rcycleContent.GetComponent<RectTransform>());
        }
        //清理描述框的文字
        describleAcrea.GetComponent<TextMeshProUGUI>().text = "";
    }

    public bool CheckListCotent(string _name)
    {
        foreach(GameObject i in taskCotentObjList)
        {
              if(i.GetComponent<TaskContent>().taskDetails._name == _name)
            {
                return true;    
            }
        }

        return false;   
    }

    public void ClearDescrible()
    {
         describleAcrea.GetComponent<TextMeshProUGUI>().text = "";
        gatheringDescrible.text = "";
        reachDescrible.text = "";
        talkDescrible.text = "";
    }
}
