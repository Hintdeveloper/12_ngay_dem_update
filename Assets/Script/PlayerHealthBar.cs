using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public float HP = 200;
    public float maxHP = 200;
    public Image healthBar;

    public void ReduceHP(float damege)
    {
        HP -= damege;
        Health(HP, maxHP);

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Health(float hp, float maxHp)
    {
        healthBar.fillAmount = hp / maxHp;
    }
}
