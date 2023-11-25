using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Game Objects
    public GameManager gameManager;
    public Shield shield;

    // Audio
    private AudioSource soundEffects;
    public AudioClip launch;
    public AudioClip gunFire;
    public AudioClip turretDestroyed;

    // Unit Movement Speed
    private float movementSpeed = 0.8f;

    // Body Rotation
    private float rotation = 0f;
    private float rotationRange = 55.0f;

    // Barrel Pivot
    [SerializeField] private GameObject barrel;
    private float arc = 0f;
    private float arcLimitMin = 35.0f;
    private float arcLimitMax = 85.0f;

    // Shell
    public GameObject shellPrefab;
    public Transform launchPoint;
    [SerializeField, Min(1)] private float shellMass = 100f;
    [SerializeField, Min(1)] private float force = 2000f;

    // Trajectory
    [SerializeField] private TrajectoryLine trajectory;

    // Bullet
    public GameObject bulletPrefab;
    public Transform gunBarrel;


    // Start
    void Start()
    {
        // Game Manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Audio
        soundEffects = GetComponent<AudioSource>();

    }

    // Update
    void Update()
    {
        // Check for Game Over
        if (!shield.gameOver)
        {
            // Rotate Turret (Left & Right Arrows)
            rotation += Input.GetAxis("Horizontal") * movementSpeed;
            rotation = Mathf.Clamp(rotation, -rotationRange, rotationRange);
            transform.localEulerAngles = new Vector3(
                transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
        
            // Pivot Cannon Barrel (Up & Down Arrows)
            arc += Input.GetAxis("Vertical") * movementSpeed;
            arc = Mathf.Clamp(arc, arcLimitMin, arcLimitMax);
            barrel.transform.localEulerAngles = new Vector3(
                arc, transform.localEulerAngles.x, transform.localEulerAngles.x);

            // Show Trajectory       
            trajectory.ShowTrajectory(launchPoint.position, launchPoint.forward * force / shellMass);      

            // Fire Cannon  (Space Bar)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }

            // Shoot Gun (Left Alt)
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Shoot();
            }
        }
        else
        {
            soundEffects.PlayOneShot(turretDestroyed);
            gameObject.SetActive(false);
        }
    }

    // Fire Cannon
    private void Fire()
    {
        soundEffects.PlayOneShot(launch, 1);

        // Load Cannon
        var projectile = Instantiate(shellPrefab, launchPoint.position, Quaternion.identity);

        // Get Rigidbody
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.mass = shellMass;

        // Fire Cannon
        rb.AddForce(launchPoint.forward * force, ForceMode.Impulse);
        gameManager.shotsFired++;
    }

    // Shoot Gun
    private void Shoot()
    {
        soundEffects.PlayOneShot(gunFire, 1);
        var bullet = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
    }
}
