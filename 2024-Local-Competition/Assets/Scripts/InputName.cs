using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public InputField inputName;

    public void Input()
    {
        GameManager.instance._name = inputName.text;
    }
}
