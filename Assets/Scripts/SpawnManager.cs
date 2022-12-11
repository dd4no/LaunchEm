using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerups;

    public float rangeX = 260f;
    public float rangeY;
    public float minRangeZ = 80f;
    public float maxRangeZ = 220f;
    public float delay = 2f;
    public float rate = 2f;

    // Start
    void Start()
    {
        InvokeRepeating("SpawnEnemy", delay, rate);
    }

    // Update
    void Update()
    {
        
    }

    // Spawn Enemy
    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-rangeX, rangeX), 1, Random.Range(minRangeZ, maxRangeZ));
        Instantiate(enemies[enemyIndex], spawnPosition, enemies[enemyIndex].transform.rotation);
    }
}
