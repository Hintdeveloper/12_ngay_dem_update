using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour
{

    public GameObject powerUpPrefab;
    public List<PowerUp> powerUpList = new List<PowerUp>();

    //void Start()
    //{
    //    powerUpList.Add(new PowerUp("DanPhao", 80));
    //}

    PowerUp GetPowerUp()
    {
        int randomNumber = Random.Range(1, 101);
        List<PowerUp> possiblePowerUp= new List<PowerUp>();
        foreach(PowerUp item in powerUpList)
        {
            if (randomNumber<=item.powerUpRate)
            {
                possiblePowerUp.Add(item);
            }
        }    
        if (possiblePowerUp.Count > 0)
        {
            PowerUp powerUpDrop = possiblePowerUp[Random.Range(0, possiblePowerUp.Count)];  
            return powerUpDrop;
        }
        return null;
    }
    public void InstantiablePowerUp(Vector3 spawnPosition)
    {
        PowerUp powerUpDrop = GetPowerUp();
        if (powerUpDrop != null)
        {
            GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
            powerUp.GetComponent<SpriteRenderer>().sprite = powerUpDrop.powerUpSprite;

            //float dropForce = 300f;
            //Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //powerUp.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce,ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }    
}
