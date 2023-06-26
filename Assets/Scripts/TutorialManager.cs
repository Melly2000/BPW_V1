using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
        popUps[popUpIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(popUpIndex);
        if (popUpIndex != 0) {
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
            if (Input.GetKeyDown("space"))
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
            if(Input.GetKeyUp("w"))
            {
                popUpIndex++;
            }
        }

    }
}
