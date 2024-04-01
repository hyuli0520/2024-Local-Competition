using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int _coin;
    public float _time;
    public int _score;
    public GameObject _shopPanel;
    public PlayerController _player;
    public GameObject _f1Cheat;
    public Text _haveMoney;
    public bool _isStart;
    public Text _timeTxt;
    public Text _StartCoolTxt;
    public string[] _goalObj;
    public Canvas _inGameCanvas;
    public bool _isPlayer;
    public Text _randomBoxTxt;
    public string _name;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }

    void Start()
    {

    }

    void Update()
    {
        if (_player == null)
            _isPlayer = false;
        if (_isStart)
        {
            _time += Time.deltaTime;
            _timeTxt.text = ((int)_time / 60).ToString() + " : " + ((int)_time % 60).ToString();
        }
        if (_isPlayer == false)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            _isPlayer = true;
        }
        _haveMoney.text = _coin.ToString() + "만원";

        Cheat();
    }

    void Cheat()
    {
        if (Input.GetButtonDown("F1"))
        {
            _f1Cheat.SetActive(!_f1Cheat.activeSelf);
        }

        if (Input.GetButton("F5"))
        {
            Time.timeScale = 0;
        }
        if (Input.GetButtonUp("F5"))
        {
            Time.timeScale = 1;
        }
    }

    public void Click100()
    {
        _coin += 100;
        _randomBoxTxt.text = "100만원";
        StartCoroutine(_player.TextOnOff());
    }
    public void Click500()
    {
        _coin += 500;
       _randomBoxTxt.text = "500만원";
        StartCoroutine(_player.TextOnOff());
    }
    public void Click1000()
    {
        _coin += 1000;
        _randomBoxTxt.text = "1000만원";
        StartCoroutine(_player.TextOnOff());
    }
    public void ClickSB()
    {
        if (_player.isSB == false)
        {
            StartCoroutine(_player.SmallBooster());
            _randomBoxTxt.text = "SmallBooster";
            StartCoroutine(_player.TextOnOff());
        }
    }
    public void ClickBB()
    {
        if (_player.isBB == false)
        {
            StartCoroutine(_player.BigBooster());
            _randomBoxTxt.text = "BigBooster";
            StartCoroutine(_player.TextOnOff());
        }
    }
    public void CloseShop()
    {
        _shopPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void CoroutineCoolDown()
    {
        for(int i = 0; i < _goalObj.Length; i++)
            _goalObj[i] = string.Empty; 

        StartCoroutine(CoolDown());
    }

    /*시작 쿨타임*/
    public IEnumerator CoolDown()
    {
        _inGameCanvas.gameObject.SetActive(true);
        _StartCoolTxt.gameObject.SetActive(true);
        _StartCoolTxt.text = 3.ToString();
        yield return new WaitForSeconds(1);
        _StartCoolTxt.text = 2.ToString();
        yield return new WaitForSeconds(1);
        _StartCoolTxt.text = 1.ToString();
        yield return new WaitForSeconds(1);
        _StartCoolTxt.gameObject.SetActive(false);
        _isStart = true;
    }
}