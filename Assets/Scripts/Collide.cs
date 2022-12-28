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
        // Destroy Projectile
        Destroy(gameObject);

        // On Ground Contact Create Crater
        if (other.CompareTag("Ground") )
        {
            return;
        }

        // On Powerup Collision Create Explosion
        if (other.CompareTag("Powerup"))
        { 
            
        }

        // On Enemy Collision Create Explosion and Slime Pool
        if (other.CompareTag("Green"))
        {

        }
        if (other.CompareTag("Blue"))
        {

        }
        if (other.CompareTag("Red"))
        {

        }

        // Destroy Target
        Destroy(other.gameObject);
    }
}
