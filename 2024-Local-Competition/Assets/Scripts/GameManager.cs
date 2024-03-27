using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int _coin;
    public float _time;
    public GameObject _shopPanel;

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
            instance = this;
    }

    void Update()
    {
        _time += Time.deltaTime;

        Cheat();
    }
    
    void Cheat()
    {
        if (Input.GetButton("F5"))
        {
            Time.timeScale = 0;
        }
        if (Input.GetButtonUp("F5"))
        {
            Time.timeScale = 1;
        }
    }


    /*·©Å© ½Ã½ºÅÛ*/
    public void Rank()
    {
        ranks.Sort((a, b) => { return b._bestScore - a._bestScore; });
    }

}