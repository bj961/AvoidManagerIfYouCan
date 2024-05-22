using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxHealth(float maxhealth)
    {
        healthSlider.maxValue = maxhealth;
        healthSlider.value = maxhealth;
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
