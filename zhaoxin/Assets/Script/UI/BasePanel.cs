using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BasePanel : MonoBehaviour
{
    protected bool isRemove = false;
    protected new string name;
    public virtual void OpenPanel(string name)
    {
        this.name = name;
        gameObject.SetActive(true);
    }
    public virtual void ClosePanel()
    {
        isRemove = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
        if (BaseUIManager.MainInstance.panelDict.ContainsKey(name))
        {
            BaseUIManager.MainInstance.panelDict.Remove(name);
        }
    }
}
