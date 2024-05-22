using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPBar : MonoBehaviour
{
    public Slider staminaSlider;

    public void SetMaxStamina(float maxStamina)
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
    }

    public void SetStamina(float currentStamina)
    {
        staminaSlider.value = currentStamina;
    }
}
