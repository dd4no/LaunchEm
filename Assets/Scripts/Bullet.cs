using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed
    private float speed = 100f;

    // Distance
    private float zRange = 200f;

    // Origin
    public Transform gun;

    // Direction
    private Vector3 direction;

    // Start
    void Start()
    {
        // Get Gun Barrel Position and Direction
        gun = GameObject.Find("Gun Barrel").transform;
        direction = gun.transform.forward;
    }

    // Update
    void Update()
    {
        // Move Bullet Forward from Gun Barrel in Direction when Fired
        transform.Translate(speed * Time.deltaTime * direction);

        // Destroy when out of bounds
        if (transform.position.z > zRange)
        {
            Destroy(gameObject);
        }
    }
}
