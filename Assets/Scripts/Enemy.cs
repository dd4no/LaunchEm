using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Shield
    private Shield shield;

    // Movement Rate
    private float speed = 5f;

    // Attack Position Y (Above Ground)
    private float attackPosition = 2.5f;

    // Countdown Timer
    public int timeUntilEscape;

    // Escape Indicator
    private bool escapeNow = false;

    // Escape Position Y (Below Ground)
    private float escapePosition = -5.0f;

    // Bullet Prefab
    public GameObject enemyBullet;

    // Shot
    private bool shotFired;
    public int shotDelay;

    
    // Start
    void Start()
    {
        // Get Player Shield
        shield = GameObject.Find("Shield").GetComponent<Shield>();
    }


    // Update
    void Update()
    {
        // Destroy Enemy when Game Over
        if (shield.gameOver)
        {
            Destroy(gameObject);
        }

        // Otherwise Rise, Attack, and Escape
        else if (!escapeNow)
        {
            Rise();
        }
        else
        {
            Sink();
        }
    }


    // Rise from Underground
    private void Rise()
    {
        // Rise up
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        // When reaching Attack Position
        if (transform.position.y >= attackPosition)
        {
            // Freeze
            transform.position = new Vector3(transform.position.x, attackPosition, transform.position.z);

            // Pause and Attack
            Invoke("Shoot", shotDelay);

            // Escape
            Invoke("Sink", timeUntilEscape);
        }

    }

    // Attack
    private void Shoot()
    {
        if (!shotFired)
        {
            // Create Bullet
            var bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);

            SoundManager.PlaySound(SoundManager.Sound.EnemyFire, 0.5f);

            // Flag as Fired
            shotFired = true;
        }
    }

    // Escape Below Ground
    private void Sink()
    {
        // Indicate Escape     
        escapeNow = true;

        // Sink
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        // Destroy at Escape Position
        if (transform.position.y < escapePosition)
        {
            SoundManager.PlaySound(SoundManager.Sound.EnemyEscape, 0.5f);
            Destroy(gameObject);
        }
    }
}
