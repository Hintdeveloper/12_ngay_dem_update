using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float destroyYThreshold = -10f;

    private float[] spawnDelays;
    private bool[] spawnCompleted;

    private float reducedSpawnDelayMultiplier = 1f; // Adjust as per your needs

    private void Start()
    {
        InitializeSpawnDelays();
        SpawnEnemies();
    }

    private void InitializeSpawnDelays()
    {
        spawnDelays = new float[spawnPoints.Length];
        spawnCompleted = new bool[spawnPoints.Length];

        for (int i = 0; i < spawnDelays.Length; i++)
        {
            if (i == 0)
            {
                spawnDelays[i] = Random.Range(1f, 3f); // Adjust the range as per your needs for element 0
            }
            else
            {
                spawnDelays[i] = 0.5f; 
            }

            spawnCompleted[i] = false;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            StartCoroutine(SpawnEnemy(i));
        }
    }

    private IEnumerator SpawnEnemy(int spawnIndex)
    {
        yield return new WaitForSeconds(spawnDelays[spawnIndex]);

        // Randomly select an enemy prefab
        GameObject randomEnemyPrefab = GetRandomEnemyPrefab();

        // Instantiate an enemy from the selected prefab at the chosen spawn point
        GameObject enemy = Instantiate(randomEnemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

        // Mark spawn as completed
        spawnCompleted[spawnIndex] = true;

        // Check if all spawns are completed
        if (AllSpawnsCompleted())
        {
            // Reset spawn completed array
            ResetSpawnCompleted();

            // Reset spawn delays for element 0
            ResetSpawnDelays();

            // Spawn the enemies again
            SpawnEnemies();
        }
    }

    private GameObject GetRandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[randomIndex];
    }

    private bool AllSpawnsCompleted()
    {
        for (int i = 0; i < spawnCompleted.Length; i++)
        {
            if (!spawnCompleted[i])
            {
                return false;
            }
        }
        return true;
    }

    private void ResetSpawnCompleted()
    {
        for (int i = 0; i < spawnCompleted.Length; i++)
        {
            spawnCompleted[i] = false;
        }
    }

    private void ResetSpawnDelays()
    {
        spawnDelays[0] *= reducedSpawnDelayMultiplier;
    }

    private void Update()
    {
        // Check if any enemies have moved out of the scene and destroy them
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.y < destroyYThreshold)
            {
                Destroy(enemy);
            }
        }
    }
}
