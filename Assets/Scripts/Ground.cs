using UnityEngine;

public class Ground : MonoBehaviour
{
    public ParticleSystem groundHit;
    public GameObject crater;

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
            Instantiate(groundHit, new Vector3(collision.transform.position.x, 0f, collision.transform.position.z), collision.transform.rotation);
            Instantiate(crater, new Vector3(collision.transform.position.x, 0f, collision.transform.position.z), transform.rotation);
        }
    }
}
