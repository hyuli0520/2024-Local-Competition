using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected List<AxleInfo> _axleInfos;
    [SerializeField] protected float _maxMotorTorque;
    [SerializeField] protected float _maxSteeringAngle;
    protected Rigidbody _rigid;
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}