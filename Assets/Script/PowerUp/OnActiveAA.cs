using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActiveAA : MonoBehaviour
{
    public GameObject[] buffSpawnPoint;
    public ShootBuff shootBuff;
    // Start is called before the first frame update
    void Start()
    {
        buffSpawnPoint = GameObject.FindGameObjectsWithTag("Buff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject spawnPoint in buffSpawnPoint) 
            {
                shootBuff.ShootingBullet(spawnPoint.transform);
            }
            Destroy(gameObject);
        }
    }


}
