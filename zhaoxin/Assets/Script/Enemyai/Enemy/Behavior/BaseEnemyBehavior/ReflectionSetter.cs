using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class ReflectionSetter : Action
{
    public BaseEnemy most;  // Ŀ����󣬰�������Ҫ���������
    public string propertyName;       // ��������
    public bool value;

    public override void OnAwake()
    { 
    most = GetComponent<BaseEnemy>();
    }
       
    public override void OnStart()
    {
        System.Type type = typeof(BaseEnemy);
        FieldInfo fieldInfo = type.GetField(propertyName);
        fieldInfo.SetValue(most, value);

    }
}