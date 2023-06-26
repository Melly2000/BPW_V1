using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider playerSlider;

    public Slider playerUseSlider;
    public Slider EnemySlider;

    public void SetMaxHealth(Slider target, int energy)
    {
        target.maxValue = energy;
        target.value = energy;
    }
    public void SetEnergy(Slider target, int energy)
    {
        target.value = energy;
    }

    public void TakeDamage(int damage, Slider targetSlider, int currentEnergy)
    {
        currentEnergy -= damage;
        SetEnergy(targetSlider, currentEnergy);
    }

}
