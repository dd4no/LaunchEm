using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Point Values
    private int greenValue = 100;
    private int blueValue = 250;
    private int redValue = 500;
    public int multiplierValue = 2;

    // Counters
    private int greenCount =0;
    private int blueCount =0;
    private int redCount = 0;
    private int multiplierCount = 0;
    private int totalEnemies = 0;
    public int shotsFired = 0;

    // Score
    private int greenPoints = 0;
    private int bluePoints = 0;
    private int redPoints = 0;
    private int bonusPoints = 0;
    private int totalPoints = 0;
    private double accuracy = 0;

    // Multiplier
    private int powerUpLength = 20;
    private bool poweredUp;
    private bool bonusActive;

    // Final Score
    private double accuracyAdjustment = 0;
    private string scoreDirection;
    private int finalScore = 0;
    private bool accuracyScoreReduction;

    // Score Display
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

    // Final Score Screen
    public TextMeshProUGUI finalScoreRedText;
    public TextMeshProUGUI finalScoreBlueText;
    public TextMeshProUGUI finalScoreGreenText;
    public TextMeshProUGUI finalScoreMultipliersText;
    public TextMeshProUGUI finalScoreTallyText;
    public TextMeshProUGUI finalScoreAccuracyText;
    public TextMeshProUGUI finalScoreText;

    // -----------------------------------------------------------------

    // Start
    void Start()
    {
        DisplayScore();
    }

    // Update
    void Update()
    {
        if (shotsFired > 0)
        {
            accuracy = Math.Round((totalEnemies * 100f / shotsFired),2);
        }
        if (poweredUp)
        {
            multiplierText.text = $"X{multiplierValue}";
        }
        if (!poweredUp)
        {
            multiplierText.text = "";
        }

        DisplayScore();
    }

    // -----------------------------------------------------------------

    // Update Score
    public void UpdateScore(string enemy, int points)
    {
        // Check for Bonus
        if (bonusActive)
        {
            // Track Bonus Points
            bonusPoints += points;

            // Multiply Score
            points *= multiplierValue;
        }

        // Update Enemy Count and Score Points 
        switch (enemy)
        {
            case "Green":
                greenCount++;
                greenPoints += points;
                break;

            case "Blue":
                blueCount++;
                bluePoints += points;
            break;

            case "Red":
                redCount++;
                redPoints += points;
            break;

            // Update Multiplier Count, Set Multiplier Value, and Start Countdown
            case "Powerup":
                multiplierCount++;
                StartCoroutine(MultiplierCountdown());
            break;
        }     

        // Update Total Count and Total Points
        totalEnemies++;
        totalPoints += points;
    }

    // Multiplier
    IEnumerator MultiplierCountdown()
    {
        poweredUp = true;
        bonusActive = true;

        yield return new WaitForSeconds(powerUpLength);

        bonusActive = false;
        poweredUp = false;
    }

    // Display Score
    public void DisplayScore()
    {
        // Counts
        greenCountText.text = $"{greenCount} GREEN:";
        blueCountText.text = $"{blueCount} BLUE:";
        redCountText.text = $"{redCount} RED:";

        // Scores
        greenPointsText.text = $"{greenPoints}";
        bluePointsText.text = $"{bluePoints}";
        redPointsText.text = $"{redPoints}";
        scoreText.text = $"{totalPoints}";

        // Accuracy
        hitsText.text = $"{totalEnemies}";
        shotsText.text = $"{shotsFired}";
        accuracyText.text = $"{accuracy}%";

        // Calculate Final Score
        CalculateFinalScore();

        // Display Final Score
        finalScoreGreenText.text = $"{greenCount} x {greenValue} = {greenCount * greenValue}";
        finalScoreBlueText.text = $"{blueCount} x {blueValue} = {blueCount * blueValue}";
        finalScoreRedText.text = $"{redCount} x {redValue} = {redCount * redValue}";
        finalScoreMultipliersText.text = $"{multiplierCount} Multipliers - {bonusPoints} Bonus Points";
        finalScoreTallyText.text = $"{totalEnemies} Total Targets - {totalPoints} Total Points";
        finalScoreAccuracyText.text = $"{accuracy}% Accuracy = {accuracyAdjustment}% Score {scoreDirection}";
        finalScoreText.text = $"Final Score = {finalScore}";
    }

    // Final Score
    private void CalculateFinalScore()
    {
        // Get Accuracy Adjustment
        CalculateAccuracyAdjustment();

        // Calculate Score Reduction
        if (accuracyScoreReduction)
        {
            finalScore = Convert.ToInt32(totalPoints - (totalPoints * accuracyAdjustment / 100));
        }
        // Set Score with no Change
        else if (accuracyAdjustment == 0)
        {
            finalScore = totalPoints;
        }
        // Calculate Score Increase
        else
        {
            finalScore = Convert.ToInt32(totalPoints + (totalPoints * accuracyAdjustment / 100));
        }
    }

    // Accuracy
    private void CalculateAccuracyAdjustment()
    {
        if (accuracy < 25)
        {
            accuracyAdjustment = 25;
            scoreDirection = "Reduction";
            accuracyScoreReduction = true;
            accuracyText.color = Color.red;
            finalScoreAccuracyText.color = Color.red;

        }
        if (accuracy >= 25 && accuracy < 50)
        {
            accuracyAdjustment = 10;
            scoreDirection = "Reduction";
            accuracyScoreReduction = true;
            accuracyText.color = Color.red;
            finalScoreAccuracyText.color = Color.red;

        }
        if (accuracy >= 50 && accuracy < 70)
        {
            accuracyAdjustment = 0;
            scoreDirection = "Effect";
            accuracyScoreReduction = false;
            accuracyText.color = Color.white;
            finalScoreAccuracyText.color = Color.white;
        }
        if (accuracy >= 70 && accuracy < 95)
        {
            accuracyAdjustment = 10;
            scoreDirection = "Increase";
            accuracyScoreReduction = false;
            accuracyText.color = Color.green;
            finalScoreAccuracyText.color = Color.green;

        }
        if (accuracy >= 95 && accuracy < 100)
        {
            accuracyAdjustment = 25;
            scoreDirection = "Increase";
            accuracyScoreReduction = false;
            accuracyText.color = Color.green;
            finalScoreAccuracyText.color = Color.green;

        }
        if (accuracy == 100)
        {
            accuracyAdjustment = 50;
            scoreDirection = "Increase";
            accuracyScoreReduction = false;
            accuracyText.color = Color.green;
            finalScoreAccuracyText.color = Color.green;
        }
    }
}
