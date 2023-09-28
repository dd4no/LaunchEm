using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float hitPoints = 10;

    public Slider slider;
    public Image sliderFill;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI shieldText;

    // Start 
    void Start()
    {
        hitPoints = 10;
        slider.value = hitPoints;
    }

    // Update 
    void Update()
    {
  
        gameOverText.text = "";

        if (hitPoints < 0) 
        {
            // Game Over Text
            gameOverText.text = "GAME OVER";
            // GameOver();
        }        
    }

    private void OnTriggerEnter(Collider other)
    {        
        hitPoints--;
        slider.value = hitPoints;

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
            // Hide
            slider.gameObject.SetActive(false);
            shieldText.gameObject.SetActive(false);
        }
    }
}
