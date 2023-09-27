using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float hitPoints = 10;
    public Slider sliderBar;
    public TextMeshProUGUI gameOverText;

    // Start 
    void Start()
    {
        hitPoints = 10;
        sliderBar.value = hitPoints;
    }

    // Update 
    void Update()
    {
        if (hitPoints < 0) 
        {
            gameOverText.text = "GAME OVER";
        }
        else
        {
            gameOverText.text = "";
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        hitPoints--;
        sliderBar.value = hitPoints;
    }
}
