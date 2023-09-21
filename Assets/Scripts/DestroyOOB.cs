using UnityEngine;

public class DestroyOOB : MonoBehaviour
{
    // ---------- Boundries ----------
    private float left = -300f;
    private float right = 300f;

    // ---------- Start ----------
    void Start()
    {
        
    }

    // ---------- Update ----------
    void Update()
    {
        if (transform.position.x < left)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > right)
        {
            Destroy(gameObject);
        }
    }
}
