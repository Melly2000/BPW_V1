using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public int enemyTotal = 10;
    private int enemyCount = 0;
    public EnergyBar energySystem;
    public Slider enemyBar;
    public GameObject bear;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount <= enemyTotal) {
            Debug.Log("Spawning enemy " + enemyCount);
            GameObject enemy = Instantiate(bear, gameObject.transform.position, Quaternion.identity);
            enemy.SendMessage("setEnergy", 50);
            enemy.SendMessage("setPlayer", GameObject.FindWithTag("Player"));
            enemy.SendMessage("setEnergySystem", energySystem);
            enemy.SendMessage("setEnergyBar", enemyBar);
            enemy.AddComponent<EnemyMovement>();
            enemy.AddComponent<EnemyCombat>();
            enemyCount++;
        }
    }
}
