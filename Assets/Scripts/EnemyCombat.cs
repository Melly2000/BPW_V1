using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    [SerializeField] int attackPower = 10;
    public PlayerCombat playerCombatScript;
    public GameObject player;
    public EnergyBar energySystem;
    public Slider energySlider;
    public int useEnergy = 10;
    public int maxEnergy = 50;
    public int currentEnergy;
    public bool isDead;
    float waitTime;

    void Start()
    {
        playerCombatScript = player.GetComponent<PlayerCombat>();
        currentEnergy = maxEnergy;
        energySystem.SetMaxHealth(energySlider, maxEnergy);
    }

    public void setEnergy(int energy)
    {
        currentEnergy = maxEnergy = energy;
    }

    public void setPlayer(GameObject p)
    {
        player = p;
    }
    public void setEnergySystem(EnergyBar bar)
    {
        energySystem = bar;
    }

    public void setEnergyBar(Slider bar)
    {
        energySlider = bar;
    }


    void Update()
    {
        animator.SetTrigger("Run Forward");
        Debug.Log(currentEnergy);
        if (currentEnergy <= 0)
        {
            animator.SetTrigger("Death");
            isDead = true;
            energySystem.SetSlider(energySlider, false);
            gameObject.SetActive(false);
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
            animator.SetTrigger("Attack1");
            playerCombatScript.TakeDamage(attackPower);
        }
    }
}

