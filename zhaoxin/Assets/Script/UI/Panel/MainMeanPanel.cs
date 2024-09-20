using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeanPanel : BasePanel 
{
    public Animator logoTitle;
    public Animator mainMeanScreen;

    public void Awake()
    {
        logoTitle.Play("TitleFadeIn");
        mainMeanScreen.Play("FadeIn");
    }
    public void StartGame()
    {
        StartCoroutine(DelayDisplayOpening());
    }
    public void Continue()
    {
        StartCoroutine(DelayDisplayComtinue());
    }
    public void Option()
    {
        StartCoroutine(DelayDisplayOptionMean());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    #region 延迟加载各种页面
    IEnumerator DelayDisplayOpening()//延迟加载开始游戏
    {
        logoTitle.Play("TileFadeOut");
        mainMeanScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.5f);
        PlayerState.isFirstLand = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator DelayDisplayComtinue()//延迟加载继续游戏
    {
        logoTitle.Play("TileFadeOut");
        mainMeanScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.5f);
        BaseUIManager.MainInstance.OpenPanel(UIConst.ContinuePanel);
        ClosePanel();
    }
    IEnumerator DelayDisplayOptionMean()//延迟加载设置菜单
    {
        logoTitle.Play("TileFadeOut");
        mainMeanScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.5f);
        BaseUIManager.MainInstance.OpenPanel(UIConst.OptionPanel);
        ClosePanel();
    }
    #endregion
}
