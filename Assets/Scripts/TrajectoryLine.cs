using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    // Line
    [SerializeField] private LineRenderer lineRenderer;

    // Line Configuration
    [SerializeField, Min(3)] private int segments = 60;
    [SerializeField, Min(1)] private float time = 10;


    // Show Trajectory Line
    public void ShowTrajectory(Vector3 startPoint, Vector3 initialVelocity)
    {
        // Get Segment Length
        float interval = time / segments;

        // Get Positions Along Arc
        Vector3[] points = CalculateTrajectory(startPoint, initialVelocity, interval);

        // Render Arc
        lineRenderer.positionCount = segments;
        lineRenderer.SetPositions(points);
    }

    // Calculate Trajectory
    public Vector3[] CalculateTrajectory(Vector3 startPoint, Vector3 initialVelocity, float interval)
    {
        // Establish Array
        Vector3[] points = new Vector3[segments];
        points[0] = startPoint;

        // Get Positions
        for (int i=1; i<segments; i++)
        {
            // Establish Position
            float offset = interval * i;

            // Calculate Progress
            Vector3 progress = initialVelocity * offset;

            // Calculate Gravity
            Vector3 gravityFactor = Vector3.up * -0.5f * Physics.gravity.y * offset * offset;

            // Create Position
            Vector3 newPoint = startPoint + progress - gravityFactor;
            points[i] = newPoint;
        }

        // Return Array of Positions
        return points;
    }
}
