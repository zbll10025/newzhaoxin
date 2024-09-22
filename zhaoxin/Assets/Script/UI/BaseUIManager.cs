using System.Collections.Generic;
using UnityEngine;
using zhou.Tool.Singleton;

public class BaseUIManager : Singleton<BaseUIManager>
{
    //路径配置字典
    private Dictionary<string, string> pathDict;
    //预制件字典
    private Dictionary<string, GameObject> prefabDict;
    //已打开界面字典
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
        //检查是否已经打开Panel
        BasePanel panel = null;
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("已打开界面：" + name);
            return null;
        }
        //检查路径是否配置
        string path = " ";
        if (!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("界面名称错误，或未配置路径：" + name);
            return null;
        }
        //得到预制件
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realPath = "Prefabs/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath);
            prefabDict.Add(name, panelPrefab);
        }
        //打开界面
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        Debug.Log(name);
        panel.OpenPanel(name);
        return panel;
    }
    public bool IsClosePanel(string name)
    {
        //检查是否打开界面且获得界面
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("界面未打开");
            return false;
        }
        return true;
    }
    public void ClosePanel(string name)
    {
        //检查是否打开界面且获得界面
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("界面未打开");
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
