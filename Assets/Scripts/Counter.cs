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
    public int greenPoints = 100;
    public int bluePoints = 250;
    public int redPoints = 500;
    public int multiplier = 2;

    // Start
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


   // Detect Hit
    private void OnCollisionEnter(Collision collision)
    {
        // Ignore Scoring on Bullets but Destroy Enemy
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.PlaySound(SoundManager.Sound.AltEnemyDestroyed, 0.5f);
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
                SoundManager.PlaySound(SoundManager.Sound.EnemyDestroyed, 0.5f);
            }
            // Blue
            if (gameObject.tag == "Blue")
            {
                gameManager.UpdateScore("Blue", bluePoints);
                SoundManager.PlaySound(SoundManager.Sound.EnemyDestroyed, 0.5f);
            }
            // Red
            if (gameObject.tag == "Red")
            {
                gameManager.UpdateScore("Red", redPoints);
                SoundManager.PlaySound(SoundManager.Sound.EnemyDestroyed, 0.5f);
            }
            // Powerup
            if (gameObject.tag == "Powerup")
            {
                gameManager.UpdateScore("Powerup", 0);
                gameManager.multiplierValue = multiplier;
                SoundManager.PlaySound(SoundManager.Sound.PowerupDestroyed, 0.5f);
            }

            // Destroy Shell and Enemy
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Show Effects
            if (gameObject.tag == "Powerup")
            {
                // Powerup Explosion
                Instantiate(powerupExplosion, transform.position, transform.rotation);
            }
            else
            {
                // Enemy Explosion
                Instantiate(enemyExplosion, new Vector3(
                    transform.position.x, 0f, transform.position.z), smokingCrater.transform.rotation);

                // Smoking Crater
                Instantiate(smokingCrater, new Vector3(
                    transform.position.x, 0f, transform.position.z), smokingCrater.transform.rotation);
            }
        }
    }
}
