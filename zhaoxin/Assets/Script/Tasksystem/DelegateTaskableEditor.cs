using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.Tasksystem
{
    [CustomEditor(typeof(DelegateTaskable)),CanEditMultipleObjects]
   
    public class DelegateTaskableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //继承基类方法
            base.OnInspectorGUI();


            DelegateTaskable tog = (DelegateTaskable)target;

            if (GUILayout.Button("更新总任务表"))
            {
                tog.TaskData_SoUpdate();
            }
        }

    }
}
