using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class ReflectionSetter : Action
{
    public BaseEnemy most;  // 目标对象，包含你需要操作的组件
    public string propertyName;       // 属性名称
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