using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shell : MonoBehaviour
{
    private Rigidbody shellBody;
    private float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        shellBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Launch(Vector3 direction)
    {
        shellBody.AddForce(direction * force, ForceMode.Impulse);
    }
}
