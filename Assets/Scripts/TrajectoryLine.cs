using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    private Vector3 endPoint2;
    public float maxDist;

    public LineRenderer lr;

    private void Awake() {
        lr  = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint) {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        startPoint.z = 0;
        endPoint.z = 0;

        var difference = endPoint - startPoint;
        var direction = difference.normalized;
        var distance = Mathf.Min(maxDist, difference.magnitude);
        endPoint = startPoint + direction * distance;
        points[0] = startPoint;
        points[1] = endPoint;

        this.endPoint2 = endPoint;

        lr.SetPositions(points);

    }

    public void EndLine() {
        lr.positionCount = 0;
    }

    public Vector3 getEndpoint() {
        return endPoint2;
    }
}
