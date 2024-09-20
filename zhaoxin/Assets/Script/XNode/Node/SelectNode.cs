using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SelectNode : BaseNode
{

    [Input(ShowBackingValue.Always)]
    public int enter;
    public string _name;
    [Output]
    public int a_exit;
    [TextArea(2,5)]
    public string a_selectDiscribe;
    [Output]
    public int b_exit;
    [TextArea(2, 5)]
    public string b_selectDiscribe;
    [Output]
    public int c_exit;
    [TextArea(2, 5)]
    public string c_selectDiscribe;
    public int offset;
    public override object GetValue(NodePort port)
    {
       this.enter = GetInputValue<int>("enter",this.enter);
        offset = this.enter;
        if (port.fieldName == "a_exit"||port.fieldName == "b_exit")
        {
            offset++;
            return offset;
        }
        return null;
    }
}
