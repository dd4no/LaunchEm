using UnityEngine;

public class Ground : MonoBehaviour
{
    // Explosion
    public ParticleSystem groundHit;

    // Crater
    public GameObject crater;


    // Detect Hits
    private void OnCollisionEnter(Collision collision)
    {  
        // Detect Shell Hit
        if (collision.gameObject.tag == "Shell")
        {
            // Play Sound Effect
            SoundManager.PlaySound(SoundManager.Sound.MissedShot, 0.5f);

            // Destroy Projectile
            Destroy(collision.gameObject);

            // Create Crater and Explosion
            Instantiate(groundHit, new Vector3(collision.transform.position.x, 0f, collision.transform.position.z), collision.transform.rotation);
            Instantiate(crater, new Vector3(collision.transform.position.x, 0f, collision.transform.position.z), transform.rotation);
        }
    }
}
