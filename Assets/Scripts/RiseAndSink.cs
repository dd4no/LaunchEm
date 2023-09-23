using UnityEngine;

public class RiseAndSink : MonoBehaviour
{
    // Movement Rate
    [SerializeField] private float speed = 5f;

    // Attack Position
    [SerializeField] private float attackPosition = 2.5f;

    // Timer
    public int timeUntilEscape;

    // Escape Flag
    public bool escapeNow = false;


    // Start
    void Start()
    {

    }

    // Update
    void Update()
    {
        if (!escapeNow)
        {
            Rise();
        }
        else
        {
            Sink();
        }
    }

    // Rise from Underground
    private void Rise()
    {
        // If at Attack Position, Freeze Position and Pause
        if (transform.position.y >= attackPosition)
        {
            transform.position = new Vector3(transform.position.x, attackPosition, transform.position.z);
            Invoke("Sink", timeUntilEscape);
        }
        // Rise up
        transform.Translate(Vector3.up * Time.deltaTime * speed);

    }

    // Sink Below Ground
    private void Sink()
    {
        // Flag Escape    
        escapeNow = true;

        // Sink
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
