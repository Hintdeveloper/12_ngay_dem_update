using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyDamage : MonoBehaviour
{
    public EnemyHealthBar enemyHealthBar;
    [SerializeField]
    private float maxHealth;
    private float curentHealth;

    //Drop item
    public GameObject[] itemToDrop;
    //Random item
    public int[] table =
    {
        20,
        20,
        20,
        20,
        20
    };
    public int total;
    public int randItem;

    //Sound play on death
    AudioManager manager;
    // Start is called before the first frame update
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        curentHealth = maxHealth;

        enemyHealthBar.SetSliderMax(maxHealth);

        foreach (var item in table)
        {
            total += item;
        }

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
                ItemDrop();
                manager.PlaySFX(manager.Death);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Enemy_1"))
            {
                CounterManager.Instance.IncreaseB52();
                ItemDrop();
                manager.PlaySFX(manager.Death);

                Destroy(gameObject);
            }
            else
            {
                CounterManager.Instance.IncreaseF4();
                ItemDrop();
                manager.PlaySFX(manager.Death);

                Destroy(gameObject);
            }
        }
    }


    void ItemDrop()
    {
        randItem = Random.Range(0, total);


        for (int i = 0; i < table.Length; i++)
        {
            if (randItem <= table[i])
            {
                Instantiate(itemToDrop[i], transform.position, Quaternion.identity);
                break;
            }
            else
            {
                randItem -= table[i];
            }
        }
    }
}
