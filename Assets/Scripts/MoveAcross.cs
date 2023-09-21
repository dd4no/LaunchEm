using UnityEngine;

public class MoveAcross : MonoBehaviour
{

    public SpawnManager spawnManager;
    private Vector3 direction;
    private float speed;

    // Start
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        direction = spawnManager.powerupDirection;
    }

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
