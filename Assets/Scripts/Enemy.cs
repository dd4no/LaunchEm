using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Movement Rate
    private float speed = 5f;

    // Attack Position
    private float attackPosition = 2.5f;

    // Countdown Timer
    public int timeUntilEscape;

    // Escape Flag
    private bool escapeNow = false;

    // Escape Position
    private float escapePosition = -5.0f;

    // Bullet Prefab
    public GameObject enemyBullet;

    // Shot
    private bool shotFired;
    public int shotDelay;


    // Start
    void Start()
    {

    }

    // Update
    void Update()
    {
        if (!escapeNow)
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

        // If at Attack Position, Freeze Position, Pause, Attack, and Initiate Escape
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

    // Shoot Gun
    private void Shoot()
    {
        if (!shotFired)
        {
            // Create Bullet
            var bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);

            // Flag as Fired
            shotFired = true;
        }
    }

    // Sink Below Ground
    private void Sink()
    {
        // Flag as Time to Escape    
        escapeNow = true;

        // Sink
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        // Destroy at Escape Position
        if (transform.position.y < escapePosition)
        {
            Destroy(gameObject);
        }
    }
}
