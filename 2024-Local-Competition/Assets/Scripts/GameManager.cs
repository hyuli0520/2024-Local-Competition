using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int _coin;
    public float _time;
    public GameObject _shopPanel;
    public PlayerController _playerController;
    public GameObject _f1Cheat;
    public Text _haveMoney;
    public bool _isStart;
    public Text _timeTxt;
    public Text _StartCoolTxt;
    public int _score;
    public GameObject _goalPanel;
    public string[] _goalObj;    

    /*bestPlayer*/
    public struct bestPlayer
    {
        public string _bestName;
        public int _bestScore;

        public bestPlayer(string bestName, int bestScore)
        {
            _bestName = bestName;
            _bestScore = bestScore;
        }
    }
    /*ranks*/
    public List<bestPlayer> ranks = new List<bestPlayer>()
    {
        new bestPlayer("-",0),
        new bestPlayer("-",0),
        new bestPlayer("-",0),
        new bestPlayer("-",0),
        new bestPlayer("-",0)
    };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ClickStart();
    }

    void Update()
    {
        if(_isStart)
        {
            _time += Time.deltaTime;
            _timeTxt.text = ((int)_time / 60).ToString() + " : " + ((int)_time % 60).ToString();
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


    /*랭크 시스템*/
    public void Rank()
    {
        ranks.Sort((a, b) => { return b._bestScore - a._bestScore; });
    }

    public void Click100()
    {
        _coin += 100;
        _playerController.randomBoxTxt.text = "100만원";
        StartCoroutine(_playerController.TextOnOff());
    }
    public void Click500()
    {
        _coin += 500;
        _playerController.randomBoxTxt.text = "500만원";
        StartCoroutine(_playerController.TextOnOff());
    }
    public void Click1000()
    {
        _coin += 1000;
        _playerController.randomBoxTxt.text = "1000만원";
        StartCoroutine(_playerController.TextOnOff());
    }
    public void ClickSB()
    {
        if (_playerController.isSB == false)
        {
            StartCoroutine(_playerController.SmallBooster());
            _playerController.randomBoxTxt.text = "SmallBooster";
            StartCoroutine(_playerController.TextOnOff());
        }
    }
    public void ClickBB()
    {
        if (_playerController.isBB == false)
        {
            StartCoroutine(_playerController.BigBooster());
            _playerController.randomBoxTxt.text = "BigBooster";
            StartCoroutine(_playerController.TextOnOff());
        }
    }

    public void ClickStart()
    {
        StartCoroutine(CoolDown());
    }
    /*시작 쿨타임*/
    private IEnumerator CoolDown()
    {
        _StartCoolTxt.gameObject.SetActive(true);
        _StartCoolTxt.text = 3.ToString();
        yield return new WaitForSeconds(1);
        _StartCoolTxt.text = 2.ToString();
        yield return new WaitForSeconds(1);
        _StartCoolTxt.text = 1.ToString();
        yield return new WaitForSeconds(1);
        _StartCoolTxt.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}