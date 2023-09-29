using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start
    void Start()
    {
    }

    // Update
    void Update()
    {

    }

    // Detect Hits
    private void OnCollisionEnter(Collision collision)
    {  
        // Detect Shell Hit
        if (collision.gameObject.tag == "Shell")
        {
            // Destroy Projectile
            Destroy(collision.gameObject);
            // Create Crater
        }
    }
}
