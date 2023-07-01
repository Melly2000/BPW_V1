using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1Manager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform lvlStart;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    private void Update()
    {
       
    }
    public void StartLvl1()
    {
        player.transform.position = lvlStart.position;
        enemy1.SetActive(true);
        enemy2.SetActive(true);
    }
}
