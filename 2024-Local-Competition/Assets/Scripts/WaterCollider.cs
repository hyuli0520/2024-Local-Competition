using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance._player._rigid.velocity = Vector3.ClampMagnitude(GameManager.instance._player._rigid.velocity, GameManager.instance._player.maxSpeed / 5);
        }
    }
}
