using UnityEngine;

public class RiseUp : MonoBehaviour
{
    // Rise Rate
    [SerializeField] private float speed = 5f;

    // Ending Point
    [SerializeField] private float readyPosition = 2.5f;

    // Start
    void Start()
    {
        
    }

    // Update
    void Update()
    {
        // Move Object Up
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        // Freeze at Ending Point
        if (transform.position.y > readyPosition)
        {
            transform.position = new Vector3(transform.position.x, readyPosition,transform.position.z);
        }
    }
}
