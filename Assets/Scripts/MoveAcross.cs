using UnityEngine;

public class MoveAcross : MonoBehaviour
{
    // Spawn Manger
    public SpawnManager spawnManager;

    // Movement Direction and Speed
    private Vector3 direction;
    private float speed;

    // Start
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        direction = spawnManager.powerupDirection;
    }

    // Awake
    private void Awake()
    {
        speed = Random.Range(40f, 80f);
    }

    // Update
    void LateUpdate()
    {        
        transform.Translate(speed * Time.deltaTime * direction);  
    }
}
