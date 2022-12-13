using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Objects to Spawn
    public GameObject[] enemies;
    public GameObject[] powerups;

    // X Range
    public float rangeX = 240f;

    // Y Range
    public float startY = -3f;

    // Z Range
    public float minRangeZ = 80f;
    public float maxRangeZ = 220f;

    // Spawn Rate
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
        Vector3 spawnPosition = new Vector3(Random.Range(-rangeX, rangeX), startY, Random.Range(minRangeZ, maxRangeZ));
        Instantiate(enemies[enemyIndex], spawnPosition, enemies[enemyIndex].transform.rotation);
    }
}
