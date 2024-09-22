using MemoryPack.Formatters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGamePanel : BasePanel
{
    public Animator continuePanel;

    public List<GameButton> gameButtons = new List<GameButton>();

    public void Awake()
    {
        
        continuePanel.Play("ContinueFadeIn");
    }
    public void Start()
    {
        SetName();
    }
    public void StartGame(int id)
    {
        if (gameButtons[id].data != null)//不是空档
        {
            StartCoroutine(DelayDisplayContinue(id));
        }
        else
        {
            StartCoroutine(DelayDisplayOpening(id));
        }
    }
    public void QuitContinuePanel()
    {
        StartCoroutine(DelayQuitContinuePanel());
    }

    #region 打开面板时初始化
    private void SetName()
    {
        for(int i = 0; i < gameButtons.Count; i++)
        {
            
            if (gameButtons[i].data == null)//如果是空存档
            {
                gameButtons[i].haveData.SetActive(true);
                gameButtons[i].image.color = new Color(1, 1, 1, 0);                                                                   
                gameButtons[i].deleteButton.SetActive(false);
                //gameButtons[i].StartButton.interactable = false;
            }
            else//有存档
            {
                
                gameButtons[i].haveData.SetActive(false);
                gameButtons[i].image.color = new Color(1, 1, 1, 1);
                gameButtons[i].deleteButton.SetActive(true);
                gameButtons[i].StartButton.interactable = true;
            }
        }
    }
    #endregion
    #region 删除游戏存档
    public void DeleteData(int id)
    {
        gameButtons[id].haveData.SetActive(true);
        gameButtons[id].image.color = new Color(1, 1, 1, 0);
        gameButtons[id].deleteButton.SetActive(false);
        //gameButtons[id - 1].StartButton.interactable = false;
        gameButtons[id].place.text = "";
        gameButtons[id].time.text = "";
        SaveSystem.DeleteFile(id.ToString());
        gameButtons[id].Load();
    }
#endregion
    #region 延迟加载各种页面
    IEnumerator DelayQuitContinuePanel()
    {
        continuePanel.Play("ContinueFadeOut");
        yield return new WaitForSeconds(1.4f);
        BaseUIManager.MainInstance.OpenPanel(UIConst.MainMenuPanel);
        ClosePanel();
    }
    IEnumerator DelayDisplayContinue(int id)//延迟加载继续游戏
    {
        continuePanel.Play("ContinueFadeOut");
        yield return new WaitForSeconds(1.4f);
        Hero.startGameid = id+1;
        Debug.Log(Hero.startGameid);
        SceneManager.LoadScene(gameButtons[id].sceneName);
        ClosePanel();
    }
    IEnumerator DelayDisplayOpening(int id)//延迟加载开始游戏
    {
        continuePanel.Play("ContinueFadeOut");
        yield return new WaitForSeconds(1.4f);
        PlayerState.isFirstLand = true;
        Hero.startGameid = id+1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion



}
