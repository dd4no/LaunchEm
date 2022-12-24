using UnityEngine;

public class Collide : MonoBehaviour
{
    // Start
    void Start()
    {
    }

    // Update
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy Shell and Target Object on Collision
        Destroy(gameObject);

        // On Ground Contact Create Crater
        if (other.CompareTag("Ground") )
        {

        }

        // On Enemy Collision Create Explosion and Slime Pool
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        // On Powerup Collision Create Explosion
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
