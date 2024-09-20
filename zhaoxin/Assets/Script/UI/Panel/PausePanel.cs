
using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : BasePanel
{
    public Animator pause;
    private CanvasGroup pauseCavas;
    private void OnEnable()
    {
        pause.Play("FadeIn");
        Time.timeScale = 0f;
        pauseCavas = GetComponent<CanvasGroup>();
    }
    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
    public void QuitPausePanel()
    {
        if (gameObject != null)
        {
           // Debug.Log("1111111111111111");
            DelayQuitPausePanel();
            //StartCoroutine(DelayQuitPausePanel());
        }
        
    }
    public void ReturnMainNeun()
    {
        StartCoroutine (DelayReturnMainNeun());
    }
    public  void Option()
    {
        StartCoroutine(DelayDisplayOptionMean());
    }
    public async void DelayQuitPausePanel()
    {
        pause.Play("FadeOut");
        //yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1f;
        await UniTask.Delay(200);
        ClosePanel();
    }
    //IEnumerator DelayQuitPausePanel()
    //{
    //    pause.Play("FadeOut");
    //    yield return new WaitForSeconds(0.2f);
    //    Debug.Log("1111111111111111");
    //    ClosePanel();
    //}
    IEnumerator DelayDisplayOptionMean()//延迟加载设置菜单
    {
        pause.Play("FadeOut");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        BaseUIManager.MainInstance.OpenPanel(UIConst.OptionPanel);
        gameObject.SetActive(false);
    }
    IEnumerator DelayReturnMainNeun()
    {
        pause.Play("FadeOut");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);//返回主菜单
        ClosePanel();
    }
}
