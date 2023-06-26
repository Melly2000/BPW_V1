using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : MonoBehaviour
{
    public PlayerCombat playerCombatScript;
    public GameObject player;
    public EnergyBar energySystem;
    public Slider energySlider;
    public int useEnergy = 10;
    public int maxEnergy = 50;
    public int currentEnergy;
    // Start is called before the first frame update
    void Start()
    {
        playerCombatScript = player.GetComponent<PlayerCombat>();
        currentEnergy = maxEnergy;
        energySystem.SetMaxHealth(energySlider, maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnergy <= 0)
        {
            Debug.Log("Player WINS!");
        }
    }


    public void TakeDamage(int damage)
    {
        currentEnergy -= damage;
        energySystem.SetEnergy(energySlider, currentEnergy);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCombatScript.TakeDamage(10);
        }
    }
}
