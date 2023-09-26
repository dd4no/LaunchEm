using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int hitPoints = 10;

    // Start 
    void Start()
    {
        hitPoints = 10;
    }

    // Update 
    void Update()
    {
        if (hitPoints < 0) 
        {
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        hitPoints--;
    }
}
