using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Objects to Spawn
    public GameObject[] enemies;
    public GameObject[] powerups;
    private float[] powerupStarts = {-400f, 400f};

    // X Range
    private float rangeX = 240f;

    // Y Positions
    private float underground = -3f;
    private float inAir = 8f;

    // Z Range
    private float minRangeZ = 80f;
    private float maxRangeZ = 220f;

    // Spawn Rate
    private float enemyDelay = 3f;
    private float powerupDelay = 20f;

    // Powerup Direction
    public Vector3 powerupDirection;


    // Start
    void Start()
    {
        // Spawn Enemies
        InvokeRepeating("SpawnEnemy", enemyDelay, Random.Range(5,15));

        // Spawn Powerups
        InvokeRepeating("SpawnPowerup", powerupDelay, Random.Range(10, 30));
    }

    // Update
    void Update()
    {
        
    }

    // Spawn Enemy
    private void SpawnEnemy()
    {
        // Generate Random Enemy
        int enemyIndex = Random.Range(0, enemies.Length);

        // Generate Random Position
        Vector3 spawnPosition = new Vector3(Random.Range(-rangeX, rangeX), underground, Random.Range(minRangeZ, maxRangeZ));

        // Spawn Enemy
        Instantiate(enemies[enemyIndex], spawnPosition, enemies[enemyIndex].transform.rotation);
    }

    // Spawn Powerup
    private void SpawnPowerup()
    {
        // Generate Random Powerup
        int powerupIndex = Random.Range(0, powerups.Length);

        // Randomize Starting Position on Right or Left
        int powerupStartIndex = Random.Range(0, 2);
        
        // Generate Random Position
        Vector3 spawnPosition = new Vector3(powerupStarts[powerupStartIndex], inAir, Random.Range(minRangeZ, maxRangeZ));

        // If Starting Position Index = 0, Move Left to Right
        if (powerupStartIndex == 0)
        {
            powerupDirection = Vector3.right;
        }
        // Otherwise, Move Right to Left
        else
        {
            powerupDirection = Vector3.left;
        }

        // Spawn Powerup
        Instantiate(powerups[powerupIndex], spawnPosition, powerups[powerupIndex].transform.rotation);
    }
}
