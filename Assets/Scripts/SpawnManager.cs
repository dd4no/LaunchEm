using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Objects to Spawn
    public GameObject[] enemies;
    public GameObject[] powerups;
    private float[] powerupStarts = {-400f, 400f};

    // X Range
    public float rangeX = 240f;

    // Y Range
    public float underground = -3f;
    public float inAirMin = 10f;
    public float inAirMax = 30f;

    // Z Range
    public float minRangeZ = 80f;
    public float maxRangeZ = 220f;

    // Spawn Rate
    public float enemyDelay = 2f;
    public float enemyRate = 2f;
    public float powerupDelay = 10f;
    public float powerupRate = 10f;

    // Powerup Direction
    public Vector3 powerupDirection;


    // Start
    void Start()
    {
        InvokeRepeating("SpawnEnemy", enemyDelay, enemyRate);
        InvokeRepeating("SpawnPowerup", powerupDelay, powerupRate);
    }

    // Update
    void Update()
    {
        
    }

    // Spawn Enemy
    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-rangeX, rangeX), underground, Random.Range(minRangeZ, maxRangeZ));
        Instantiate(enemies[enemyIndex], spawnPosition, enemies[enemyIndex].transform.rotation);
    }

    // Spawn Powerup
    private void SpawnPowerup()
    {
        int powerupIndex = Random.Range(0, powerups.Length);
        int powerupStartIndex = Random.Range(0, 2);

        Vector3 spawnPosition = new Vector3(powerupStarts[powerupStartIndex], Random.Range(inAirMin, inAirMax), Random.Range(minRangeZ, maxRangeZ));

        if (powerupStartIndex == 0)
        {
            powerupDirection = Vector3.right;
        }
        else
        {
            powerupDirection = Vector3.left;
        }

        Instantiate(powerups[powerupIndex], spawnPosition, powerups[powerupIndex].transform.rotation);
    }
}
