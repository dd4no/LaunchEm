using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // ---------- Objects ----------
    public GameManager gameManager;

    // ---------- Variables ----------
    public int greenPoints = 10;
    public int bluePoints = 25;
    public int redPoints = 50;
    public int powerUp = 2;

    // ---------- Start ----------
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // ---------- Trigger ----------
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Green"))
        {
            gameManager.UpdateScore("Green", greenPoints);
        }
        if (CompareTag("Blue"))
        {
            gameManager.UpdateScore("Blue", bluePoints);
        }
        if (CompareTag("Red"))
        {
            gameManager.UpdateScore("Red", redPoints);
        }
        if (CompareTag("Powerup"))
        {
            gameManager.UpdateScore("Powerup", 0);
        }
    }
}
