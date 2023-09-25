using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 200f;
    private Vector3 direction;
    private GameObject turret;

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

        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
}
