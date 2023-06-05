using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject enemies;
    public Rigidbody targetToKill;
    public float spawnInterval = 2f;
    public float spawnVectorX = 50f;
    public float spawnVectorZ = 50f;

    private float timer = 0f;
   
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval )
        {
            SpawmEnemy();
            timer = 0f;
        }
    }

    void SpawmEnemy()
    {
        float enemyInX = Random.Range(-spawnVectorX, spawnVectorZ);
        float enemyInZ = Random.Range(-spawnVectorZ, spawnVectorX);

        Vector3 spawnPosition = new Vector3(enemyInX, 0f, enemyInZ);

        Vector3 direction = (targetToKill.position - transform.position.normalized);
        Quaternion rotation = Quaternion.LookRotation(direction);

        Instantiate(enemies, spawnPosition,rotation);
    }
}
