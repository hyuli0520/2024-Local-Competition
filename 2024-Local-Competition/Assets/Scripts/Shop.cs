using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button desertWheel;
    public Button mountainWheel;
    public Button cityWheel;
    public Button sixEngine;
    public Button eightEngine;

    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;
    public GameObject check5;

    bool desert;
    bool mount;
    bool city;
    bool six;
    bool eight;

    void Start()
    {
        desert = false;
        mount = false;
        city = false;
        six = false;
        eight = false;
    }

    public void ClickDesert()
    {
        if (Input.GetButton("F2"))
        {
            if (desert == false)
            {
                GameManager.instance._player.isDesert = true;
                desert = true;
                check1.SetActive(true);
            }
        }
        else
        {
            if (GameManager.instance._coin > 300 && desert == false)
            {
                GameManager.instance._coin -= 300;
                GameManager.instance._player.isDesert = true;
                desert = true;
                check1.SetActive(true);
            }
        }
    }
    public void ClickMountain()
    {
        if (Input.GetButton("F2"))
        {
            if (mount == false)
            {
                GameManager.instance._player.isMountain = true;
                mount = true;
                check2.SetActive(true);
            }
        }
        else
        {
            if (GameManager.instance._coin > 800 && mount == false)
            {
                GameManager.instance._coin -= 800;
                GameManager.instance._player.isMountain = true;
                mount = true;
                check2.SetActive(true);
            }
        }
    }
    public void ClickCity()
    {
        if (Input.GetButton("F2"))
        {
            if (city == false)
            {
                GameManager.instance._player.isCity = true;
                city = true;
                check3.SetActive(true);
            }
        }
        else
        {
            if (GameManager.instance._coin > 1200 && city == false)
            {
                GameManager.instance._coin -= 1200;
                GameManager.instance._player.isCity = true;
                city = true;
                check3.SetActive(true);
            }
        }
    }
    public void ClickSix()
    {
        if (Input.GetButton("F2"))
        {
            if (six == false)
            {
                GameManager.instance._player._speed *= 1.2f;
                GameManager.instance._player.maxSpeed += 4f;
                six = true;
                check4.SetActive(true);
            }
        }
        else
        {
            if (GameManager.instance._coin > 3500 && six == false)
            {
                GameManager.instance._coin -= 3500;
                GameManager.instance._player._speed *= 1.2f;
                GameManager.instance._player.maxSpeed += 4f;
                six = true;
                check4.SetActive(true);
            }
        }
    }
    public void ClickEight()
    {
        if (Input.GetButton("F2"))
        {
            if (eight == false)
            {
                GameManager.instance._player._speed *= 1.4f;
                GameManager.instance._player.maxSpeed += 8f;
                eight = true;
                check5.SetActive(true);
            }
        }
        else
        {
            if (GameManager.instance._coin > 5000 && eight == false)
            {
                GameManager.instance._coin -= 5000;
                GameManager.instance._player._speed *= 1.4f;
                GameManager.instance._player.maxSpeed += 8f;
                eight = true;
                check5.SetActive(true);
            }
        }
    }
}
