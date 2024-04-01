using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public string sceneName;
    public string thisSceneName;

    public void ClickMain()
    {
        GameManager.instance._inGameCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void ClickNextStage()
    {
        GameManager.instance._time = 0;
        GameManager.instance._timeTxt.text = "0 : 0";
        if (string.IsNullOrEmpty(GameManager.instance._name))
        {
            Debug.Log("이름을 입력해 주세요.");
            return;
        }
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        GameManager.instance.CoroutineCoolDown();
    }

    public void ClickRetryStage()
    {
        GameManager.instance._time = 0;
        GameManager.instance._timeTxt.text = "0 : 0";
        SceneManager.LoadScene(thisSceneName);
        Time.timeScale = 1;
        GameManager.instance.CoroutineCoolDown();
    }

    public void ClickRank()
    {
        SceneManager.LoadScene("Ranking");
    }
}
