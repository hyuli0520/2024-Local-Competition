using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Character
{
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        collider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    void Update()
    {
        float motor = _maxMotorTorque * Input.GetAxis("Vertical");
        float steering = _maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in _axleInfos)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                axleInfo.leftWheel.brakeTorque = 500;
                axleInfo.rightWheel.brakeTorque = 500;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
            }
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

    }
}
