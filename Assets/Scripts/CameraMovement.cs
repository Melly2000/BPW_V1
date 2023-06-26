using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
  
    void Update()
    {
        transform.position = CameraPosition.position;
    }
}
