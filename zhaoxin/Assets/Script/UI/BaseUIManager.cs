using System.Collections.Generic;
using UnityEngine;
using zhou.Tool.Singleton;

public class BaseUIManager : Singleton<BaseUIManager>
{
    //·�������ֵ�
    private Dictionary<string, string> pathDict;
    //Ԥ�Ƽ��ֵ�
    private Dictionary<string, GameObject> prefabDict;
    //�Ѵ򿪽����ֵ�
    public Dictionary<string, BasePanel> panelDict;
    private static BaseUIManager instance;

    private Transform uiRoot;
    public Transform UIRoot
    {
        get
        {
            if (uiRoot == null)
            {
                if (GameObject.Find("Canvas"))
                {
                    uiRoot = GameObject.Find("Canvas").transform;
                }
                else
                {
                    uiRoot = new GameObject("Canvas").transform;
                }
            }
            return uiRoot;
        }
    }
    private BaseUIManager()
    {
        InitDicts();
    }
    private void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        pathDict = new Dictionary<string, string>()
        {
            { UIConst.MainMenuPanel,"UIPanel/MainMenuPanel"},
            { UIConst.OptionPanel,"UIPanel/OptionPanel"},
            { UIConst.ContinuePanel,"UIPanel/ContinueGamePanel" },
            { UIConst.PlayerHealthUI,"UIPanel/PlayerHealthUI" },
            { UIConst.PausePanel,"UIPanel/PausePanel" },
            { UIConst.TalkPanel,"UIPanel/TalkPanel"}
        };

    }
    public BasePanel OpenPanel(string name)
    {
        //����Ƿ��Ѿ���Panel
        BasePanel panel = null;
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("�Ѵ򿪽��棺" + name);
            return null;
        }
        //���·���Ƿ�����
        string path = " ";
        if (!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("�������ƴ��󣬻�δ����·����" + name);
            return null;
        }
        //�õ�Ԥ�Ƽ�
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realPath = "Prefabs/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath);
            prefabDict.Add(name, panelPrefab);
        }
        //�򿪽���
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        Debug.Log(name);
        panel.OpenPanel(name);
        return panel;
    }
    public bool IsClosePanel(string name)
    {
        //����Ƿ�򿪽����һ�ý���
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("����δ��");
            return false;
        }
        return true;
    }
    public void ClosePanel(string name)
    {
        //����Ƿ�򿪽����һ�ý���
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("����δ��");
            return;
        }
        panel.ClosePanel();
        return;
    }
}
public class UIConst
{
    public const string MainMenuPanel = "MainMenuPanel";
    public const string OptionPanel = "OptionPanel";
    public const string ContinuePanel = "ContinuePanel";
    public const string PlayerHealthUI = "PlayerHealthUI";
    public const string PausePanel = "PausePanel";
    public const string TalkPanel = "TalkPanel";
}
