using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.TerrainTools;

namespace Assets.Script.Tasksystem
{
    [System.Serializable]
    public class TaskDetails 
    {
        [Header("任务基本信息")]
        public string _name;
        public string id;
        public Image taskImage;
        public string description;
        [Header("任务类型")]
        public TaskType Type;
        [Header("任务目标")]
        public bool isreach;
        public bool istalk;
        public int  goalcount;
        public int getcount;
        [Header("任务状态")]
        public TotalStatus status;
        [Header("是否有前置任务")]
        public bool isper;
        public List<string> Pre_task_ID_list;
        [Header("奖励")]
        public float money;
    }

    

}

