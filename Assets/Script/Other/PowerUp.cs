using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PowerUp:ScriptableObject
{
    public Sprite powerUpSprite;
    public string powerUpName;
    public int powerUpRate;

    public PowerUp(string powerUpName,int powerUpRate)
    {
        this.powerUpName = powerUpName;
        this.powerUpRate = powerUpRate;
    }
}
