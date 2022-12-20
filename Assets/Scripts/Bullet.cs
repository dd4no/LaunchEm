using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 40f;
    public Transform gun;
    private Vector3 direction;

    // Start
    void Start()
    {
        gun = GameObject.Find("Gun Barrel").transform;
        direction = gun.transform.forward;
    }

    // Update
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
