using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int NumberOfPickups { get; private set; }

    public void PickupCollected()
    {
        NumberOfPickups++;
    }
}
