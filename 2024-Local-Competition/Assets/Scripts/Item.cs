using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider != null && (collider.tag == "Player" || collider.tag == "PlayerCol"))
        {
            Destroy(this.gameObject);
        }
    }
}
