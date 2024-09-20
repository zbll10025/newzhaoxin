using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : BaseNode
{
    [Input(ShowBackingValue.Always)]
     public int enter;
     public string _name;
    [TextArea(3,10)]
    public List<string> content;
     [Output] public int exit;
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
