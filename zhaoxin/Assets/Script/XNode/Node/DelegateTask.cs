using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DelegateTask :BaseNode
{
    [Input(ShowBackingValue.Always)]
    public int enter;
    [Header("任务相关")]
    public string Tasksid;
    public TotalStatus taskStatus;
    [Output] public int waittingexit;
    [Output] public int acceptedexit;
    [Output] public int completedexit;
    [Output] public int failedexit;
    public override object GetValue(NodePort port)
    {

        this.enter = GetInputValue<int>("enter", this.enter);

        if (port.fieldName == "exit")
        {
            return enter + 1;
        }
        return null;
    }
    
}
