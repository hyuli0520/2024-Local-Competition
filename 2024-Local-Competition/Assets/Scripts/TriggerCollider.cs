using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxCol
{
    sideCol,
    frontCol,
    backCol,
}

public class TriggerCollider : MonoBehaviour
{
    public BoxCol boxCol;
    public PlayerController player;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (boxCol == BoxCol.sideCol)
            {
                player._rigid.velocity -= new Vector3(1, 0, 1);
            }
            if (boxCol == BoxCol.frontCol)
            {
                player._rigid.velocity -= new Vector3(2, 0, 2);
            }
            if (boxCol == BoxCol.backCol)
            {
                player._rigid.velocity += new Vector3(1, 0, 1);
            }
        }
    }
}
