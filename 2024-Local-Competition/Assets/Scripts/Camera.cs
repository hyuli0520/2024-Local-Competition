using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float _followSpeed;
    public GameObject _cameraTarget;
    public GameObject _followCamera;

    void FixedUpdate()
    {
        if (_cameraTarget == null || _followCamera == null)
            return;

        transform.LookAt(_cameraTarget.transform);
        transform.position = Vector3.Lerp(transform.position, _followCamera.transform.position, Time.deltaTime * _followSpeed);
    }
}
