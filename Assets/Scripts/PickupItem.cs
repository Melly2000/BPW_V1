using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Pickup pickup = other.GetComponent<Pickup>();

        if (pickup != null)
        {
            pickup.PickupCollected();
            gameObject.SetActive(false);
        }
    }
}
