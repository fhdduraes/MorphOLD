using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomCollider : MonoBehaviour
{
    public BoxCollider LivingRoom;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LivingRoom.isTrigger = false;
            Destroy(gameObject);
        }
    }
}
