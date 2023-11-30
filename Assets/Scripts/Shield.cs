using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    // Effects
    public GameObject effects;
    public ParticleSystem turretExplosion;
    public ParticleSystem shieldHit;

    // Audio
    private AudioSource soundEffects;
    public AudioClip shieldDamage;
    public AudioClip shieldDestroyed;
    public AudioClip turretDestroyed;

    // Hit Points
    public float hitPoints = 10;

    // Health Bar
    public Slider slider;
    public Image sliderFill;

    // Display Text
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI shieldDestroyedText;
    public TextMeshProUGUI gameOverText;

    // End of Game
    public GameObject scoreScreen;
    public GameObject gameOverScreen;
    public bool gameOver;


    // Start 
    void Start()
    {
        // Initialize Shield
        gameOver = false;
        hitPoints = 10;
        slider.value = hitPoints;
        soundEffects = effects.GetComponent<AudioSource>();
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
            Instantiate(shieldHit, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);            

            // Take Damage
            hitPoints--;

            // Play Sound Effect
            if(hitPoints > 0)
            {
                soundEffects.PlayOneShot(shieldDamage, .1f);
            }


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
                // Destroy Sheild
                soundEffects.PlayOneShot(shieldDestroyed);
                slider.gameObject.SetActive(false);
                shieldText.gameObject.SetActive(false);
                shieldDestroyedText.gameObject.SetActive(true);
            }
        }
    }


    // End Game
    private void GameOver()
    {
        soundEffects.PlayOneShot(turretDestroyed, 1);

        // Mark Game as Over
        gameOver = true;

        // Show Effects
        turretExplosion.Play();
        gameObject.SetActive(false);

        // Hide Score Screen
        scoreScreen.gameObject.SetActive(false);

        // Show Game Over Screen
        gameOverScreen.gameObject.SetActive(true);
    }
}
