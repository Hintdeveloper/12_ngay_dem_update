using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

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
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
