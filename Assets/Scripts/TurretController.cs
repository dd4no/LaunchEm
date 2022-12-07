using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Unit Movement Speed
    private float movementSpeed = 2.0f;

    // Body Rotation
    private float rotation = 0f;
    private float rotationRange = 55.0f;

    // Barrel Pivot
    public GameObject barrel;
    private float arc = 0f;
    private float arcLimit = 60.0f;

    // Shell
    public Shell shellPrefab;
    public Transform shellSpawnPosition;
    public float force = 100;

    void Start()
    {
        
    }

    void Update()
    {
        // Rotate Turret Body
        rotation += Input.GetAxis("Horizontal") * movementSpeed;
        rotation = Mathf.Clamp(rotation, -rotationRange, rotationRange);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
        
        // Pivot Barrel
        arc += Input.GetAxis("Vertical") * movementSpeed;
        arc = Mathf.Clamp(arc, arcLimit, 90);
        barrel.transform.localEulerAngles = new Vector3(arc, transform.localEulerAngles.x, transform.localEulerAngles.x);

        // Fire Cannon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shellPrefab, shellSpawnPosition.position, shellSpawnPosition.rotation).Launch(shellSpawnPosition.forward * force * Time.deltaTime);
        }
    }
}
