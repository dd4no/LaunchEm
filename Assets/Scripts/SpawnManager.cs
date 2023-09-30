using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ---------- Spawn Arrays ----------
    public GameObject[] enemies;
    public GameObject[] powerups;

    public Shield shield;

    // ---------- Spawn Location Ranges ----------

    // X
    private float[] powerupRangeX = { -300f, 300f };
    private float enemyRangeX = 200f;

    // Y
    private float underground = -3f;
    private float[] aboveGroundHeights = { 10f, 20f, 30f};

    // Z
    private float minRangeZ = 100f;
    private float maxRangeZ = 200f;

    // ---------- Initial Spawn Rates ----------
    private float enemyDelay = 3f;
    private float powerupDelay = 20f;

    // ---------- Directions ----------
    public Vector3 powerupDirection;


    // ---------- Start ----------
    void Start()
    {
        // Spawn Enemies
        InvokeRepeating("SpawnEnemy", enemyDelay, Random.Range(5,15));

        // Spawn Powerups
        InvokeRepeating("SpawnPowerup", powerupDelay, Random.Range(10, 30));
    }

    // ---------- Update ----------
    void Update()
    {
        // Stop Spawning when Game Over
        if (shield.gameOver)
        { 
            CancelInvoke();
        }        
    }

    // ---------- Spawn Enemy ----------
    private void SpawnEnemy()
    {
        // Generate Random Enemy
        int enemyIndex = Random.Range(0, enemies.Length);

        // Generate Random Position
        Vector3 spawnPosition = new Vector3(Random.Range(-enemyRangeX, enemyRangeX), underground, Random.Range(minRangeZ, maxRangeZ));

        // Spawn Enemy
        Instantiate(enemies[enemyIndex], spawnPosition, enemies[enemyIndex].transform.rotation);
    }

    // ---------- Spawn Powerup ----------
    private void SpawnPowerup()
    {
        // Generate Random Powerup
        int powerupIndex = Random.Range(0, powerups.Length);

        // Generate Random Starting Position - Left or Right
        int powerupStartIndex = Random.Range(0, 2);

        // Generate Starting Direction based on Starting Position
        // -Left to Right
        if (powerupStartIndex == 0)
        {
            powerupDirection = Vector3.right;
        }
        // -Right to Left
        else
        {
            powerupDirection = Vector3.left;
        }
        // Generate Random Starting Position above Ground
        int aboveGroundIndex = Random.Range(0, 3);
        
        // Generate Random Spawn Position
        Vector3 spawnPosition = new Vector3(powerupRangeX[powerupStartIndex], aboveGroundHeights[aboveGroundIndex], Random.Range(minRangeZ, maxRangeZ));


        // Spawn Powerup
        Instantiate(powerups[powerupIndex], spawnPosition, powerups[powerupIndex].transform.rotation);
    }
}
