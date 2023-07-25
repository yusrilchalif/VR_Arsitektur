using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathIndicator : MonoBehaviour
{
    public Transform target;
    public float pointSpacing = 0.1f; // Distance between each point in the trail
    private NavMeshPath navMeshPath;
    private LineRenderer lineRenderer;

    private void Start()
    {
        navMeshPath = new NavMeshPath();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false; // Disable the line renderer initially
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the path using NavMesh
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, navMeshPath);

            // Enable the line renderer to start drawing the path
            lineRenderer.enabled = true;

            // Create a list of points for the line renderer
            Vector3[] pathCorners = navMeshPath.corners;
            int pointCount = Mathf.FloorToInt(Vector3.Distance(transform.position, target.position) / pointSpacing) + 1;
            Vector3[] points = new Vector3[pointCount];

            float currentDist = 0f;
            for (int i = 0; i < pointCount; i++)
            {
                float normalizedDist = currentDist / Vector3.Distance(transform.position, target.position);
                points[i] = Vector3.Lerp(transform.position, target.position, normalizedDist);
                currentDist += pointSpacing;
            }

            // Set the positions for the line renderer based on the points
            lineRenderer.positionCount = pointCount;
            lineRenderer.SetPositions(points);
        }
        else
        {
            // If the target is null, disable the line renderer
            lineRenderer.enabled = false;
        }
    }
}
