using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCollider : MonoBehaviour
{
    public BoxCollider LivingRoomCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LivingRoomCollider.isTrigger = true;
            Destroy(gameObject);
        }
    }
}
