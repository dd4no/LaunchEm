using UnityEngine;

public class Counter : MonoBehaviour
{
    // Game Manager
    private GameManager gameManager;

    // Effects
    public ParticleSystem smokingCrater;
    public ParticleSystem enemyExplosion;
    public ParticleSystem powerupExplosion;

    // Point Values
    public int greenPoints = 10;
    public int bluePoints = 25;
    public int redPoints = 50;
    public int multiplier = 2;

    // Start
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   // Detect Hit
    private void OnCollisionEnter(Collision collision)
    {
        // Ignore Scoring on Bullets
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            return;
        }

        // Ignore Enemy Bullets and Update Appropriate Score
        if (collision.gameObject.tag != "EnemyFire")
        {
            // Green
            if (gameObject.tag =="Green")
            {
                gameManager.UpdateScore("Green", greenPoints);
            }
            // Blue
            if (gameObject.tag == "Blue")
            {
                gameManager.UpdateScore("Blue", bluePoints);
            }
            // Red
            if (gameObject.tag == "Red")
            {
                gameManager.UpdateScore("Red", redPoints);
            }
            // Powerup
            if (gameObject.tag == "Powerup")
            {
                gameManager.UpdateScore("Powerup", 0);
                gameManager.multiplierValue = multiplier;
            }

            // Destroy Shell and Enemy
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Show Effects
            if (gameObject.tag == "Powerup")
            {
                Instantiate(powerupExplosion, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(enemyExplosion, new Vector3(transform.position.x, 0f, transform.position.z), smokingCrater.transform.rotation);
                Instantiate(smokingCrater, new Vector3(transform.position.x, 0f, transform.position.z), smokingCrater.transform.rotation);
            }
        }
    }
}
