using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ShellLauncher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Shell;

    [SerializeField]
    private GameObject Barrel;

    [SerializeField]
    private LineRenderer LineRenderer;

    [SerializeField]
    private Transform ReleasePosition;

    [SerializeField]
    [Range(1, 100)]
    private float LaunchStrenth = 10f;

    [SerializeField]
    [Range(10, 100)]
    private int LinePoints;

    [SerializeField]
    [Range(0.1f, 0.25f)]
    private float TimeBetweenPoints = 0.1f;

    private Transform InitialParent;
    private Vector3 InitialPosition;
    private Quaternion InitialRotation;

    private LayerMask ShellCollisionMask;


    void Awake()
    {
        InitialParent = Shell.transform.parent;
        InitialPosition = Shell.transform.localPosition;
        InitialRotation = Shell.transform.localRotation;
        Shell.freezeRotation = true;

    }

    void Update()
    {
        
    }

    private void DrawTrajectory()
    {
        LineRenderer.enabled = true;
        LineRenderer.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints + 1);
        Vector3 startPosition = ReleasePosition.position;
        Vector3 startVelocity = LaunchStrenth * Barrel.transform.forward / Shell.mass;
        int i = 0;
        LineRenderer.SetPosition(i, startPosition);
        for (float time=0; time<LinePoints; time+=TimeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            LineRenderer.SetPosition(i, point);

            Vector3 lastPosition = LineRenderer.GetPosition(i - 1);

            if (Physics.Raycast(lastPosition,
                (point - lastPosition).normalized,
                out RaycastHit hit,
                (point - lastPosition).magnitude,
                ShellCollisionMask))
            {
                LineRenderer.SetPosition(i, hit.point);
                LineRenderer.positionCount = i + 1;
                return;
            }
        }
    }
}
