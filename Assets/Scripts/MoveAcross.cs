using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcross : MonoBehaviour
{

    public SpawnManager spawnManager;
    private Vector3 direction;
    private float speed;

    // Start
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        direction = spawnManager.powerupDirection;
    }

    private void Awake()
    {
        speed = Random.Range(30f, 100f);
    }

    // Update
    void LateUpdate()
    {
        
        transform.Translate(direction * Time.deltaTime * speed);  
    }
}
