using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject basicEnemyPrefab;
    public GameObject intermediateEnemyPrefab;
    public GameObject bossEnemyPrefab;

    public Transform[] spawnPoints; 
    public float spawnInterval = 5f; 

    private void Start()
    {
        
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
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

