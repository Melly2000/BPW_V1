using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    private Quaternion savedRotation;
    [SerializeField] GameObject pickup;
    [SerializeField] GameObject enemy;
    private bool isActive;
    private PickupItem pickupScript;
    public GameObject player;



    void Start()
    {
        popUpIndex = 0;
        popUps[popUpIndex].SetActive(true);
        savedRotation = player.transform.rotation;
        pickupScript = pickup.GetComponent<PickupItem>();
    }

    void Update()
    {
        Debug.Log(popUpIndex);
        if (popUpIndex != 0)
        {
            popUps[popUpIndex - 1].SetActive(true);
        }
        popUps[popUpIndex].SetActive(true);
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown("d") || Input.GetKeyDown("a") || Input.GetKeyDown("w") || Input.GetKeyDown("s"))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            bool hasRotated = player.transform.rotation != savedRotation;
            if (hasRotated)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            bool space = Input.GetKey("space");
            bool w = Input.GetKey("w");
            if (space && w)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4 && pickupScript.pickableObject)
        {
            if (Input.GetKey("e"))
            {
                Debug.Log("Pick up collected");
                isActive = true;
                enemy.SetActive(true);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (!isActive)
            {
                Debug.Log("You beat the tutorial!");
                // next scene
            }
        }

    }
}
