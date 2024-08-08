using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject basicEnemyPrefab;
    public GameObject intermediateEnemyPrefab;
    public GameObject bossEnemyPrefab;

    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f; 
    private float countdown = 2f; 

    public int numberOfWaves = 5; 
    private int currentWave = 0;

    public int enemiesPerWave = 5; 
    private int enemiesSpawned = 0;

    private void Update()
    {
        if (currentWave < numberOfWaves)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves; 
            }

            countdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave()
    {
        currentWave++;
        enemiesSpawned = 0;

        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(0.5f); 
        }
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        int enemyType = Random.Range(0, 3);
        GameObject enemyPrefab = null;

        switch (enemyType)
        {
            case 0:
                enemyPrefab = basicEnemyPrefab;
                break;
            case 1:
                enemyPrefab = intermediateEnemyPrefab;
                break;
            case 2:
                enemyPrefab = bossEnemyPrefab;
                break;
        }

        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

