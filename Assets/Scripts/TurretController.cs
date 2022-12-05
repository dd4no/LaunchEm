using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private float movementSpeed = 2.0f;

    private float rotation = 0f;
    private float rotationRange = 55.0f;

    public GameObject barrel;
    private float arc = 0f;
    private float arcLimit = 60.0f;


    void Start()
    {
        
    }

    void Update()
    {
        //rotationInput += Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, Time.deltaTime * movementSpeed * rotationInput);

        rotation += Input.GetAxis("Horizontal") * movementSpeed;
        rotation = Mathf.Clamp(rotation, -rotationRange, rotationRange);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
        
        arc += Input.GetAxis("Vertical") * movementSpeed;
        arc = Mathf.Clamp(arc, arcLimit, 90);
        barrel.transform.localEulerAngles = new Vector3(arc, transform.localEulerAngles.x, transform.localEulerAngles.x);

        //barrel.transform.Rotate(Vector3.left, Time.deltaTime * movementSpeed * arcInput);
        
    }
}
