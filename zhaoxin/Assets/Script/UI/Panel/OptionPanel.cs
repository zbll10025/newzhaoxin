using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : BasePanel
{
    private PausePanel pausePanel;

    public Image backGround;

    public Animator optionMeanScreen;
    public void Awake()
    {
        optionMeanScreen.Play("FadeIn");
        backGround = GetComponent<Image>();
        if (BaseUIManager.MainInstance.IsClosePanel(UIConst.PausePanel))//如果是从暂停界面打开的 
        {
            pausePanel = FindObjectOfType<PausePanel>();
            backGround.color = new Color(0, 0 , 0 , 0.8627451f);
        }
        else
        {
            backGround.color = new Color(0, 0, 0, 0);
        }
        
    }
    public void QuitOptionPanel()
    {
        StartCoroutine(DelayQuitOptionPanel());
    }
    IEnumerator DelayQuitOptionPanel()
    {
        optionMeanScreen.Play("FadeOut");
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        if (!BaseUIManager.MainInstance.IsClosePanel(UIConst.PausePanel))
        {
            BaseUIManager.MainInstance.OpenPanel(UIConst.MainMenuPanel);
        }
        else
        {
            pausePanel.gameObject.SetActive(true);
        }
        ClosePanel();
    }
}
