using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public static Rank instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnEnable()
    {
        RankSort();
    }


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
        new bestPlayer("-", 0),
        new bestPlayer("-", 0),
        new bestPlayer("-", 0),
        new bestPlayer("-", 0),
        new bestPlayer("-", 0)
    };

    public Text[] bestNameTxt;
    public Text[] bestScoreTxt;

    /*·©Å© ½Ã½ºÅÛ*/
    public void RankSort()
    {
        ranks.Add(new bestPlayer(GameManager.instance._name, GameManager.instance._score));
        ranks.Sort((a, b) => { return b._bestScore - a._bestScore; });

        for (int i = 0; i < 5; i++)
        {
            bestNameTxt[i].text = ranks[i]._bestName.ToString();
            bestScoreTxt[i].text = ranks[i]._bestScore.ToString();
        }
    }

}
