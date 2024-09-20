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
    #region �ӳټ��ظ���ҳ��
    IEnumerator DelayDisplayOpening()//�ӳټ��ؿ�ʼ��Ϸ
    {
        logoTitle.Play("TileFadeOut");
        mainMeanScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.5f);
        PlayerState.isFirstLand = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator DelayDisplayComtinue()//�ӳټ��ؼ�����Ϸ
    {
        logoTitle.Play("TileFadeOut");
        mainMeanScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.5f);
        BaseUIManager.MainInstance.OpenPanel(UIConst.ContinuePanel);
        ClosePanel();
    }
    IEnumerator DelayDisplayOptionMean()//�ӳټ������ò˵�
    {
        logoTitle.Play("TileFadeOut");
        mainMeanScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.5f);
        BaseUIManager.MainInstance.OpenPanel(UIConst.OptionPanel);
        ClosePanel();
    }
    #endregion
}
