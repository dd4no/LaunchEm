using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public Transform gunBarrel;

    // Start
    void Start()
    {
        
    }

    // Update
    void Update()
    {
        transform.Translate(gunBarrel.forward * Time.deltaTime * speed);
    }
}
