using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyHealthBar enemyHealthBar;
    [SerializeField]
    private float maxHealth;
    private float curentHealth;

    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;

        enemyHealthBar.SetSliderMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        curentHealth -= amount;
        enemyHealthBar.SetSlider(curentHealth);

        if (curentHealth <= 0)
        {
            if(gameObject.CompareTag("Enemy"))
            {
                CounterManager.Instance.IncreaseA6();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Enemy_1"))
            {
                CounterManager.Instance.IncreaseB52();
                Destroy(gameObject);
            }
            else
            {
                CounterManager.Instance.IncreaseF4();
                Destroy(gameObject);
            }
        }
    }

}
