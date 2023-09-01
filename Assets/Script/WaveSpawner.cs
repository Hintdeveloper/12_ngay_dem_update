using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1.0f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    public int[] table =
    {
        50,
        40,
        10
    };
    public int total;
    public int randEnemy;

    private void Start()
    {
        foreach (var item in table)
        {
            total += item;
        }
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
    }
    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return waitForSeconds;

            randEnemy = Random.Range(0, total);


            for (int i = 0; i < table.Length; i++)
            {
                if (randEnemy <= table[i])
                {
                    Instantiate(enemyPrefabs[i], transform.position, Quaternion.identity);
                    break;
                }
                else
                {
                    randEnemy -= table[i];
                }
            }

        }
    }


}