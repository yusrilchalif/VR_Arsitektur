using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererController : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position);
            lineRenderer.SetPosition(1, endTransform.position);
        }
    }
    public void SetLinePoints(Vector3 startPos, Vector3 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    public void DisableLine()
    {
        lineRenderer.enabled = false;
    }

    public void EnableLine()
    {
        lineRenderer.enabled = true;
    }
}
