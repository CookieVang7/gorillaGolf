using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public Transform Ball;

    public Vector2 minPower;
    public Vector2 maxPower;
    TrajectoryLine tl;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    bool hittable2 = false;


        private void Start() {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update() {
       if (Input.GetMouseButtonDown(0) && OnMouseOverBall.hittable) {
          hittable2 = true;

          Debug.Log("Drag: " + OnMouseOverBall.hittable);
          var mousePosition = Input.mousePosition;
          mousePosition.z = 15;
          startPoint = cam.ScreenToWorldPoint(mousePosition);
          startPoint.z = 15;
       }
      
      if (Input.GetMouseButton(0) && hittable2) {
          var mousePosition = Input.mousePosition;
          mousePosition.z = 15;
          Vector3 currentPoint = cam.ScreenToWorldPoint(mousePosition);
          currentPoint.z = 15;
          var myStartPoint = new Vector3();
          myStartPoint.x = Ball.position.x;
          myStartPoint.y = Ball.position.y;
          tl.RenderLine(myStartPoint, currentPoint);

      }

      if (Input.GetMouseButtonUp(0) && hittable2) {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 15;
         endPoint = cam.ScreenToWorldPoint(mousePosition);
         endPoint.z = 15;

         force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
         rb.AddForce(force * power * -1, ForceMode2D.Impulse);
         tl.EndLine();
         hittable2 = false;

      }
   }
}

