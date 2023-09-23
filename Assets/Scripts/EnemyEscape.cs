using UnityEngine;

public class EnemyEscape : MonoBehaviour
{
    private float escapePosition = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < escapePosition)
        {
            Destroy(gameObject);
        }
    }
}
