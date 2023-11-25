using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Velocity
    private float speed = 200f;

    // Origin
    private GameObject turret;

    // Direction
    private Vector3 direction;

    // Start
    void Start()
    {
        // Get Turret Location
        turret = GameObject.Find("Body");

        // Set Attack Direction
        direction = (turret.transform.position - transform.position).normalized;
    }

    // Update
    void Update()
    {
        // Move Bullet from Enemy toward Turret
        transform.Translate(speed * Time.deltaTime * direction);

        // Destroy Bullet
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
}
