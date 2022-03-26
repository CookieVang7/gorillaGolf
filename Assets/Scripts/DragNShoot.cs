using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;
    TrajectoryLine tl;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Start() {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update() {
       if (Input.GetMouseButtonDown(0)) {
           var mousePosition = Input.mousePosition;
           mousePosition.z = 15;
          startPoint = cam.ScreenToWorldPoint(mousePosition);
          startPoint.z = 15;
       }
      
      if (Input.GetMouseButton(0)) {
          var mousePosition = Input.mousePosition;
          mousePosition.z = 15;
          Vector3 currentPoint = cam.ScreenToWorldPoint(mousePosition);
          Debug.Log("CurrentPosition: " + currentPoint);
          currentPoint.z = 15;
          tl.RenderLine(startPoint, currentPoint);

      }

      if (Input.GetMouseButtonUp(0)) {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 15;
         endPoint = cam.ScreenToWorldPoint(mousePosition);
         endPoint.z = 15;

         force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
         rb.AddForce(force * power, ForceMode2D.Impulse);
         tl.EndLine();

      }
   }
}

