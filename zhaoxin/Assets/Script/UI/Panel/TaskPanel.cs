using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel :BasePanel
{
    [Header("��ʾ��������Ҫ���أ�")]
    public GameObject describleAcrea;
    public TextMeshProUGUI gatheringDescrible;
    public TextMeshProUGUI reachDescrible;
    public TextMeshProUGUI talkDescrible;
    public TaskData_So TaskData_So;
    [Header("��������")]
    public GameObject content;//�������������
    public GameObject rcycleContent;//����pool�صĻ��ղ�Ӱ��ui��ʾ
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
    
        GameObject obj =PoolManger.Instance.Get("TaskCotent",path);//����TaskButton
        obj.GetComponent<RectTransform>().SetParent(contentRecttrasform);//���ø�����
        taskCotentObjList.Add(obj);//�����б������
        TaskContent taskContent = obj.GetComponent<TaskContent>();//��ȡ�������ڵ�task�����

        ////��������
        taskContent.taskDetails = data;//�����ݴ����Ӧ��BUtton
        taskContent.status =  data.status;
        taskContent.type = data.Type;
        taskContent.taskDescribe = describleAcrea.GetComponent<TextMeshProUGUI>();//����UI������������
        taskContent.reachDescrible = reachDescrible;
        taskContent.gatheringDescrible = gatheringDescrible;
        taskContent.talkDescrible = talkDescrible;
        ////

        Button button = obj.GetComponent<RectTransform>().Find("Button").GetComponent<Button>();
        TextMeshProUGUI buttonMesh = obj.GetComponent<RectTransform>().Find("Button").GetComponent<RectTransform>().Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        buttonMesh.text = data._name;
        obj.SetActive(true);
        //�󶨰�ť�¼�����ֵ
       
        //button.onClick.AddListener(Show);
    }
    public void Show()
    {

    }

    public void ClearTaskCotent()
    {
        //ͨ��tco�б����������е�������
        foreach(GameObject i in taskCotentObjList)
        {
            PoolManger.Instance.Recycle("TaskCotent", i);
            i.GetComponent<RectTransform>().SetParent(rcycleContent.GetComponent<RectTransform>());
        }
        //���������������
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
