using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public float maxLineLengthY;
    public float minLineLengthY;
    public float maxLineLengthX;
    public float minLineLengthX;
    public LineRenderer lr;

    private void Awake() {
        lr  = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint) {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        startPoint.z = 0;
        endPoint.z = 0;
        endPoint.x = Mathf.Clamp(endPoint.x, endPoint.x + minLineLengthX, endPoint.x + maxLineLengthX);
        endPoint.y = Mathf.Clamp(endPoint.y, endPoint.y - minLineLengthY, endPoint.y - maxLineLengthY);
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);

    }

    public void EndLine() {
        lr.positionCount = 0;
    }
}
