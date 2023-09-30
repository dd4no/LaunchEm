using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    // Hit Points
    public float hitPoints = 10;

    // Health Bar
    public Slider slider;
    public Image sliderFill;

    // Display Text
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI gameOverText;

    // End of Game
    public GameObject scoreScreen;
    public GameObject gameOverScreen;
    public bool gameOver;

    // Start 
    void Start()
    {
        gameOver = false;
        hitPoints = 10;
        slider.value = hitPoints;
    }

    // Update 
    void Update()
    {
        // End Game on Final Hit
        if (hitPoints < 0)
        {
            // End Game
            GameOver();

        }        
    }

    // Detect Hit
    private void OnCollisionEnter(Collision collision)
    {        
        // Detect Enemy Shots Only
        if (collision.gameObject.tag == "EnemyFire") 
        {
            // Take Damage
            hitPoints--;

            // Indicate Damage on Health Bar
            slider.value = hitPoints;

            // Change Color as Damage Increases
            if (hitPoints <= 7 && hitPoints >= 4)
            {
                // Yellow
                sliderFill.color = Color.yellow;
            }
            if (hitPoints <= 3 && hitPoints >= 1)
            {
                // Red
                sliderFill.color = Color.red;
            }
            if (hitPoints == 0)
            {
                // Hide Health Bar on Last Hit
                slider.gameObject.SetActive(false);
                shieldText.gameObject.SetActive(false);
            }
        }
    }

    // End Game
    private void GameOver()
    {
        // End Game
        gameOver = true;

        // Hide Score Screen
        scoreScreen.gameObject.SetActive(false);

        // Show Game Over Screen
        gameOverScreen.gameObject.SetActive(true);
    }
}
