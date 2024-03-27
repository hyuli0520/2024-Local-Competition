using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Character
{
    float _h, _v;
    bool isRotation;
    bool isShop;

    void Start()
    {
        _speed = 8f;

        _boxCollider = GetComponent<BoxCollider>();
        _rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveCar();

        if (Input.GetKeyDown(KeyCode.R) && isRotation == false)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
            int rand = Random.Range(0, 1);
            transform.position = new Vector3(transform.position.x + rand, transform.position.y + 5, transform.position.z + rand);
            isRotation = true;
            StartCoroutine(RotationCool());
        }
    }

    /*�÷��̾� �̵�*/
    void MoveCar()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, 10);
        _rigid.AddForce(transform.forward * _v * _speed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.forward = Vector3.Lerp(transform.forward, transform.right * _h, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.forward = Vector3.Lerp(transform.forward, transform.right * _h, Time.deltaTime);
        }

        //if(Input.GetKey(KeyCode.Space))
        //{
        //    PhysicMaterial physicMaterial = new PhysicMaterial();
        //    physicMaterial.s
        //}
    }
    /*�÷��̾� ���� ���� ��Ÿ��*/
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
                    Debug.Log("100����");
                    break;
                case 2:
                    GameManager.instance._coin += 500;
                    Debug.Log("500����");
                    break;
                case 3:
                    GameManager.instance._coin += 1000;
                    Debug.Log("1000����");
                    break;
                case 4:
                    StartCoroutine(SmallBooster());
                    Debug.Log("SmallBooster");
                    break;
                case 5:
                    StartCoroutine(BigBooster());
                    Debug.Log("BigBooster");
                    break;
                default:
                    if (!isShop)
                    {
                        OpenShop();
                        Debug.Log("Shop");
                    }
                    break;
            }
        }
    }

    /*�ӵ� ���� ���� ����*/
    IEnumerator SmallBooster()
    {
        _speed *= 1.2f;
        _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, 12);
        yield return new WaitForSeconds(1.5f);
        _speed /= 1.2f;
    }
    /*�ӵ� ���� ���� ����*/
    IEnumerator BigBooster()
    {
        _speed *= 1.5f;
        _rigid.velocity = Vector3.ClampMagnitude(_rigid.velocity, 15);
        yield return new WaitForSeconds(1.5f);
        _speed /= 1.5f;
    }

    void OpenShop()
    {
        Time.timeScale = 0;
        GameManager.instance._shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        Time.timeScale = 1;
        GameManager.instance._shopPanel.SetActive(false);
    }
}
