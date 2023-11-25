using UnityEngine;

public class SunriseSunset : MonoBehaviour
{
    // Sun Passage Rate
    public int rateOfTime = 5;

    // Update 
    void Update()
    {
        // Orbit Light Source continually from Left to Right
        transform.Rotate(Vector3.right, transform.position.x * Time.deltaTime/rateOfTime);
    }
}
