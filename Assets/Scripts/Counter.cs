using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text GreenCounterText;
    public Text BlueCounterText;
    public Text RedCounterText;
    public Text PowerupCounterText;

    public int GreenCount;
    public int BlueCount;
    public int RedCount;
    public int PowerupCount;
    public int TotalCount;


    private void Start()
    {
        //GreenCount = 0;
        //BlueCount = 0;
        //RedCount = 0;
        //PowerupCount = 0;
        //TotalCount = 0;

        //GreenCounterText = Text.Find("GreenCounter");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            GreenCount += 1;
            GreenCounterText.text = "Count : " + GreenCount;
            Debug.Log(GreenCount);
        }
        if (other.CompareTag("Blue"))
        {
            BlueCount += 1;
            BlueCounterText.text = "Count : " + BlueCount;
            Debug.Log(BlueCount);
        }
        if (other.CompareTag("Red"))
        {
            RedCount += 1;
            RedCounterText.text = "Count : " + RedCount;
            Debug.Log(RedCount);
        }
        if (other.CompareTag("Powerup"))
        {
            PowerupCount += 1;
            PowerupCounterText.text = "Count : " + PowerupCount;
            Debug.Log(PowerupCount);
        }

        TotalCount = GreenCount + BlueCount + RedCount + PowerupCount;
        Debug.Log(TotalCount);
    }
}
