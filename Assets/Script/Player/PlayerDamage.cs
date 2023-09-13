using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDamage : MonoBehaviour
{

    public PlayerHealthBar PlayerHealthBar;
    [SerializeField]
    private float maxHealth;
    private float curentHealth;
    //Check if player is destroyed
    bool isDestroyed;
    //Call game over
    public GameManager gameManager;

    //PLay voice on death
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;

        PlayerHealthBar.SetSliderMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        curentHealth -= amount;
        PlayerHealthBar.SetSlider(curentHealth);

        if (curentHealth <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            audioManager.PlaySFX(audioManager.Death);
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }

    public void IncreaseHP(float amount)
    {
        curentHealth += amount;

        PlayerHealthBar.SetSlider(curentHealth);

        if (curentHealth >= maxHealth) 
        {
            curentHealth = maxHealth;
        }
    }
}
