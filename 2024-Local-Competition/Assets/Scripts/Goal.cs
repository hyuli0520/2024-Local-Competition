using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    Text goalText;
    Text scoreText;
    Button NextBtn;
    Button ReBtn;

    void OnTriggerEnter(Collider collider)
    {
        if (GameManager.instance._goalObj[0] == null)
            GameManager.instance._goalObj[0] = collider.gameObject.tag;
        else
            GameManager.instance._goalObj[1] = collider.gameObject.tag;

        if (collider.tag == "Player")
        {
            if (GameManager.instance._goalObj[0] == "Player")
            {
                Time.timeScale = 0;
                GameManager.instance._isStart = false;
                GameManager.instance._shopPanel.SetActive(true);
                GameManager.instance._goalPanel.SetActive(true);
                goalText.text = "Time : " + ((int)GameManager.instance._time / 60).ToString() + " : " + ((int)GameManager.instance._time % 60).ToString();
                GameManager.instance._score += 3000 - (int)GameManager.instance._time;
                scoreText.text = "Score : " + (3000 - (int)GameManager.instance._time).ToString();
                NextBtn.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                GameManager.instance._isStart = false;
                GameManager.instance._shopPanel.SetActive(true);
                GameManager.instance._goalPanel.SetActive(true);
                goalText.text = "Time : " + ((int)GameManager.instance._time / 60).ToString() + " : " + ((int)GameManager.instance._time % 60).ToString();
                GameManager.instance._score += 3000 - (int)GameManager.instance._time;
                scoreText.text = "Score : " + (3000 - (int)GameManager.instance._time).ToString();
                ReBtn.gameObject.SetActive(true);
            }
        }
    }
}
