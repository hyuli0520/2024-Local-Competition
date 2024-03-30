using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text goalText;
    public Text scoreText;
    public Text gradeText;
    public Button NextBtn;
    public Button ReBtn;
    public GameObject goalPanel;

    void OnTriggerEnter(Collider collider)
    {
        if (string.IsNullOrEmpty(GameManager.instance._goalObj[0]))
            GameManager.instance._goalObj[0] = collider.gameObject.tag;
        else
            GameManager.instance._goalObj[1] = collider.gameObject.tag;

        if (collider.tag == "Player" || collider.tag == "PlayerCol")
        {
            if (GameManager.instance._goalObj[0] == "Player" || GameManager.instance._goalObj[0] == "PlayerCol")
            {
                Time.timeScale = 0;
                GameManager.instance._isStart = false;
                goalPanel.SetActive(true);
                gradeText.text = "1µî";
                goalText.text = "Time : " + ((int)GameManager.instance._time / 60).ToString() + " : " + ((int)GameManager.instance._time % 60).ToString();
                GameManager.instance._score += 3000 - (int)GameManager.instance._time;
                scoreText.text = "Score : " + (3000 - (int)GameManager.instance._time).ToString();
                NextBtn.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                GameManager.instance._isStart = false;
                goalPanel.SetActive(true);
                gradeText.text = "2µî";
                goalText.text = "Time : " + ((int)GameManager.instance._time / 60).ToString() + " : " + ((int)GameManager.instance._time % 60).ToString();
                GameManager.instance._score += 3000 - (int)GameManager.instance._time;
                scoreText.text = "Score : " + (3000 - (int)GameManager.instance._time).ToString();
                ReBtn.gameObject.SetActive(true);
            }
        }

    }
    public void ClickNext()
    {
        SceneManager.LoadScene(GameManager.instance._nextScene);

        StartCoroutine(GameManager.instance.CoolDown());
    }

    public void ClickShop()
    {
        PlayerController player = new PlayerController();
        player.OpenShop();
    }
}
