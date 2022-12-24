using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 60f;
    public Transform gun;
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

        if (transform.position.z > 240)
        {
            Destroy(gameObject);
        }
    }
}
