using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Counters
    public int greenScore;
    public int blueScore;
    public int redScore;
    public int powerupScore;
    public int totalScore;

    // Score Displays
    public TextMeshProUGUI greenScoreText;
    public TextMeshProUGUI blueScoreText;
    public TextMeshProUGUI redScoreText;
    public TextMeshProUGUI powerupScoreText;
    public TextMeshProUGUI totalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount(string enemy)
    {
        switch (enemy)
        {
            case "Green":
                greenScore++;
                greenScoreText.text = "Green Enemies: " + greenScore;
                Debug.Log("Green: " + greenScore);
                break;
            case "Blue":
                blueScore++;
                blueScoreText.text = "Blue Enemies: " + blueScore;
                Debug.Log("Blue: " + blueScore);

                break;
            case "Red":
                redScore++;
                redScoreText.text = "Red Enemies: " + redScore;
                Debug.Log("Red: " + redScore);

                break;
            case "Powerup":
                powerupScore++;
                powerupScoreText.text = "Powerups: " + powerupScore;
                Debug.Log("Green: " + powerupScore);

                break;
        }     

        totalScore++;
        totalScoreText.text = "Total Enemies: " + totalScore;

    }
}
