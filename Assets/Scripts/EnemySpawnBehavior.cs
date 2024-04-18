using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBehavior : MonoBehaviour
{
    public float spawnTimer;
    public int enemyCode;

    public Transform enemySpawnPoint;
    public GameObject enemyPrefab;
    public GameObject variantEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = UnityEngine.Random.Range(1, 10);        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0) 
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {        
        enemyCode = UnityEngine.Random.Range(1, 100);

        if(enemyCode >= 50)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
        else if(enemyCode < 50)
        {
            Instantiate(variantEnemyPrefab, transform.position, Quaternion.identity);
        }

        spawnTimer = UnityEngine.Random.Range(5, 10);
    }
}
