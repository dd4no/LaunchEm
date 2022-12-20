using UnityEngine;

public class Shell : MonoBehaviour
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
        // Destroy on Ground Contact
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
