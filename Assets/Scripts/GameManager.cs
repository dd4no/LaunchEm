using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ---------- Variables ----------

    // Counters
    private int greenCount;
    private int blueCount;
    private int redCount;
    private int powerUpCount;
    public int shotsFired;
    private int totalEnemies;

    // Score
    private int greenPoints;
    private int bluePoints;
    private int redPoints;
    private int totalPoints;
    private double accuracy;

    // Multiplier
    private int powerUpMultiplier;
    private int powerUpLength;
    private bool poweredUp;
    private bool bonus;
    public int bonusPoints;

    // Score Displays
    public TextMeshProUGUI greenCountText;
    public TextMeshProUGUI greenPointsText;
    public TextMeshProUGUI blueCountText;
    public TextMeshProUGUI bluePointsText;
    public TextMeshProUGUI redCountText;
    public TextMeshProUGUI redPointsText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hitsText;
    public TextMeshProUGUI shotsText;
    public TextMeshProUGUI accuracyText;

    // ---------- Start ----------
    void Start()
    {
        // Initialize Counts
        greenCount = 0;
        blueCount = 0;
        redCount = 0;
        powerUpCount = 0;
        shotsFired = 0;
        totalEnemies = 0;

        // Initialize Score
        greenPoints = 0;
        bluePoints = 0;
        redPoints = 0;
        totalPoints = 0;
        accuracy = 0;

        // Set Multiplier
        powerUpMultiplier = 2;
        powerUpLength = 20;
        poweredUp = false;
        bonus = false;
        bonusPoints = 0;

        // Intialize Display
        DisplayScore();
    }

    // ---------- Update ----------
    void Update()
    {
        if (shotsFired > 0)
        {
            accuracy = Math.Round((totalEnemies * 100f / shotsFired),2);
        }
        if (poweredUp)
        {
            multiplierText.text = $"X{powerUpMultiplier}";
        }
        if (!poweredUp)
        {
            multiplierText.text = "";
        }

        DisplayScore();
    }

    // ---------- Scoring ----------
    public void UpdateScore(string enemy, int points)
    {
        // Check for Bonus
        if (bonus)
        {
            // Multiply Score
            points = points * powerUpMultiplier;

            // Track Bonus Points
            bonusPoints = points * powerUpMultiplier;
        }

        // Score Enemy Count and Points 
        switch (enemy)
        {
            case "Green":
                greenCount++;
                greenPoints = greenPoints + points;
                break;

            case "Blue":
                blueCount++;
                bluePoints = bluePoints + points;
            break;

            case "Red":
                redCount++;
                redPoints = redPoints + points;
            break;

            case "Powerup":
                powerUpCount++;
                StartCoroutine(PowerUpCountdown());
            break;
        }     

        // Add to Total Count and Total Points
        totalEnemies++;
        totalPoints = totalPoints + points;
    }

    // ---------- PowerUp ----------
    IEnumerator PowerUpCountdown()
    {
        poweredUp = true;
        bonus = true;

        yield return new WaitForSeconds(powerUpLength);

        bonus = false;
        poweredUp = false;
    }

    // ---------- Display ----------
    public void DisplayScore()
    {
        // Counts
        greenCountText.text = $"{greenCount}";
        blueCountText.text = $"{blueCount}";
        redCountText.text = $"{redCount}";
        hitsText.text = $"{totalEnemies}";
        shotsText.text = $"{shotsFired}";

        // Scores
        greenPointsText.text = $"{greenPoints}";
        bluePointsText.text = $"{bluePoints}";
        redPointsText.text = $"{redPoints}";
        scoreText.text = $"{totalPoints}";
        accuracyText.text = $"{accuracy}%";
    }
}
