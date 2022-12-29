using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Green"))
        {
            gameManager.UpdateCount("Green");
        }
        if (CompareTag("Blue"))
        {
            gameManager.UpdateCount("Blue");

        }
        if (CompareTag("Red"))
        {
            gameManager.UpdateCount("Red");

        }
        if (CompareTag("Powerup"))
        {
            gameManager.UpdateCount("Powerup");

        }
    }
}
