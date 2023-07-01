using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public int energyAmountStored;
    public bool pickableObject;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("pickable");
            pickableObject = true;
            Pickup pickup = other.GetComponent<Pickup>();

            if (pickup != null && Input.GetKey("e"))
            {
                Debug.Log("pickup");
                pickup.PickupCollected();
                gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        pickableObject = false;
    }
}
