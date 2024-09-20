using MemoryPack.Formatters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGamePanel : BasePanel
{
    public Animator continuePanel;

    public List<GameButton> gameButtons = new List<GameButton>();

    public void Awake()
    {
        SetName();
        continuePanel.Play("ContinueFadeIn");
    }
    public void StartGame(int id)
    {
        StartCoroutine(DelayDisplayOpening(id));
    }
    public void QuitContinuePanel()
    {
        StartCoroutine(DelayQuitContinuePanel());
    }

    
    private void SetName()
    {
        for(int i = 0; i < gameButtons.Count; i++)
        {
            
            if (gameButtons[i].place.text=="")//如果没有存档
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
    public void DeleteData(int id)
    {
        gameButtons[id - 1].haveData.SetActive(true);
        gameButtons[id - 1].image.color = new Color(1, 1, 1, 0);
        gameButtons[id - 1].deleteButton.SetActive(false);
        //gameButtons[id - 1].StartButton.interactable = false;
        gameButtons[id - 1].place.text = "";
        gameButtons[id - 1].time.text = "";
        SaveSystem.DeleteFile(id.ToString());
    }
    #region 延迟加载各种页面
    IEnumerator DelayQuitContinuePanel()
    {
        continuePanel.Play("ContinueFadeOut");
        yield return new WaitForSeconds(1.4f);
        BaseUIManager.MainInstance.OpenPanel(UIConst.MainMenuPanel);
        ClosePanel();
    }
    IEnumerator DelayDisplayOpening(int id)
    {
        continuePanel.Play("ContinueFadeOut");
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(gameButtons[id - 1].sceneName);
        ClosePanel();
    }
    #endregion



}
