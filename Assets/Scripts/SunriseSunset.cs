using UnityEngine;

public class SunriseSunset : MonoBehaviour
{
    public int rateOfTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, transform.position.x * Time.deltaTime/rateOfTime);
    }
}
