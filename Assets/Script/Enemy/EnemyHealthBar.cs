using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    private void Update()
    {
    }
    public void SetSlider(float amount)
    {
        healthBar.value = amount;
    }
    public void SetSliderMax(float amount)
    {
        healthBar.maxValue = amount;
        SetSlider(amount);
    }
}
