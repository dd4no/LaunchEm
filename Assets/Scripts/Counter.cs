using UnityEngine;

public class Counter : MonoBehaviour
{
    // Game Manager
    private GameManager gameManager;

    // Point Values
    public int greenPoints = 10;
    public int bluePoints = 25;
    public int redPoints = 50;
    public int multiplier = 2;

    // Start
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   // Detect Hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "EnemyFire")
        {
            if (gameObject.tag =="Green")
            {
                gameManager.UpdateScore("Green", greenPoints);
            }
            if (gameObject.tag == "Blue")
            {
                gameManager.UpdateScore("Blue", bluePoints);
            }
            if (gameObject.tag == "Red")
            {
                gameManager.UpdateScore("Red", redPoints);
            }
            if (gameObject.tag == "Powerup")
            {
                gameManager.UpdateScore("Powerup", 0);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
