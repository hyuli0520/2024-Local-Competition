using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Character
{
    float _h, _v;
    bool isRotation;
    bool isShop;
    public bool isDesert = false;
    public bool isMountain = false;
    public bool isCity = false;
    public bool isSB = false;
    public bool isBB = false;
    public float maxSpeed;
    RaycastHit hit;

    void Start()
    {
        _speed = 700f;
        maxSpeed = 18;
        _boxCollider = GetComponent<BoxCollider>();
        _rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if (GameManager.instance._isStart)
        {
            MoveCar();

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
            {
                if (hit.transform.CompareTag("NotRoad"))
                    _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, maxSpeed / 3);
            }

            if (Input.GetKeyDown(KeyCode.R) && isRotation == false)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                int rand = Random.Range(0, 1);
                transform.position = new Vector3(transform.position.x + rand, transform.position.y + 5, transform.position.z + rand);
                isRotation = true;
                StartCoroutine(RotationCool());
            }
        }
    }

    /*플레이어 이동*/
    void MoveCar()
    {
        _rigid.AddForce(transform.forward * _v * _speed * Time.deltaTime);
        Debug.Log(transform.forward);

        if (isSB)
            _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, maxSpeed + 5);
        else if (isBB)
            _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, maxSpeed + 10);
        else
            _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, maxSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * _h);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * _h);
        }
    }
    /*플레이어 원상 복구 쿨타임*/
    private IEnumerator RotationCool()
    {
        yield return new WaitForSeconds(2f);
        isRotation = false;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Item")
        {
            int random = Random.Range(0, 7);
            switch (random)
            {
                case 1:
                    GameManager.instance._coin += 100;
                    GameManager.instance._randomBoxTxt.text = "100만원";
                    StartCoroutine(TextOnOff());
                    break;
                case 2:
                    GameManager.instance._coin += 500;
                    GameManager.instance._randomBoxTxt.text = "500만원";
                    StartCoroutine(TextOnOff());
                    break;
                case 3:
                    GameManager.instance._coin += 1000;
                    GameManager.instance._randomBoxTxt.text = "1000만원";
                    StartCoroutine(TextOnOff());
                    break;
                case 4:
                    StartCoroutine(SmallBooster());
                    GameManager.instance._randomBoxTxt.text = "SmallBooster";
                    StartCoroutine(TextOnOff());
                    break;
                case 5:
                    StartCoroutine(BigBooster());
                    GameManager.instance._randomBoxTxt.text = "BigBooster";
                    StartCoroutine(TextOnOff());

                    break;
                default:
                    if (!isShop)
                    {
                        Invoke("OpenShop", 1.3f);
                        GameManager.instance._randomBoxTxt.text = "상점";
                        StartCoroutine(TextOnOff());
                    }
                    break;
            }
        }
    }

    /*속도 순간 소폭 증가*/
    public IEnumerator SmallBooster()
    {
        isSB = true;
        _speed *= 1.4f;
        yield return new WaitForSeconds(1.5f);
        _speed /= 1.4f;
        isSB = false;
    }
    /*속도 순간 대폭 증가*/
    public IEnumerator BigBooster()
    {
        isBB = true;
        _speed *= 1.8f;
        yield return new WaitForSeconds(1.5f);
        _speed /= 1.8f;
        isBB = false;
    }
    /*RandomBoxText*/
    public IEnumerator TextOnOff()
    {
        GameManager.instance._randomBoxTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.instance._randomBoxTxt.gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        GameManager.instance._shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        GameManager.instance._shopPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
