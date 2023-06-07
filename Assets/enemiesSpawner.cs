using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float spawnRangeX = 30f;
    public float spawnRangeZ = 30f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {     
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);
    
        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);

        //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.parent = transform; // Establecer el objeto spawneado como hijo del objeto "enemiesSpawner"
    }
}
