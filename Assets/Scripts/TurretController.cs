using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Unit Movement Speed
    [SerializeField] private float movementSpeed = 3.0f;

    // Body Rotation
    private float rotation = 0f;
    [SerializeField] public float rotationRange = 55.0f;

    // Barrel Pivot
    [SerializeField] private GameObject barrel;
    private float arc = 0f;
    [SerializeField] public float arcLimitMin = 35.0f;
    [SerializeField] public float arcLimitMax = 85.0f;

    // Shell
    public GameObject shellPrefab;
    public Transform launchPoint;
    [SerializeField, Min(1)] private float shellMass = 100;
    [SerializeField, Min(1)] private float force = 2000;

    // Trajectory
    [SerializeField] private TrajectoryLine trajectory;


    // Start
    void Start()
    {
    }

    // Update
    void Update()
    {
        // Rotate Turret (Left & Right Arrows)
        rotation += Input.GetAxis("Horizontal") * movementSpeed;
        rotation = Mathf.Clamp(rotation, -rotationRange, rotationRange);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
        
        // Pivot Cannon Barrel (Up & Down Arrows)
        arc += Input.GetAxis("Vertical") * movementSpeed;
        arc = Mathf.Clamp(arc, arcLimitMin, arcLimitMax);
        barrel.transform.localEulerAngles = new Vector3(arc, transform.localEulerAngles.x, transform.localEulerAngles.x);

        // Show Trajectory       
        trajectory.ShowTrajectory(launchPoint.position, launchPoint.forward * force / shellMass);      

        // Fire Cannon  (Space Bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    // Fire Cannon
    private void Fire()
    {
        // Load Cannon
        var projectile = Instantiate(shellPrefab, launchPoint.position, Quaternion.identity);

        // Get Rigidbody
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.mass = shellMass;

        // Fire Cannon
        rb.AddForce(launchPoint.forward * force, ForceMode.Impulse);
    }
}
