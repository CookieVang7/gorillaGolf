using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    [SerializeField]
    private float maxDistanceBallGorilla;
    public float power = 10f;
    public Rigidbody2D rb;
    public Transform Ball;
    public Transform Gorilla;

    public Vector2 minPower;
    public Vector2 maxPower;
    TrajectoryLine tl;
    Camera cam;
     public Transform cameraTransform;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    bool hittable2 = false;


        private void Start() {
        cam = FindObjectOfType<Camera>();
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update() {
       if (Input.GetMouseButtonDown(0) && OnMouseOverBall.hittable && Vector3.Distance(Ball.position, Gorilla.position) <= maxDistanceBallGorilla) {
          hittable2 = true;
            Debug.Log(Vector3.Distance(Ball.position, Gorilla.position));

          Debug.Log("Drag: " + OnMouseOverBall.hittable);
          var mousePosition = Input.mousePosition;
          mousePosition.z = -cameraTransform.position.z;
          startPoint = cam.ScreenToWorldPoint(mousePosition);
          startPoint.z = -cameraTransform.position.z;
       }
      
      if (Input.GetMouseButton(0) && hittable2) {
          var mousePosition = Input.mousePosition;
          mousePosition.z = -cameraTransform.position.z;
           Vector3 currentPoint = cam.ScreenToWorldPoint(mousePosition);
          currentPoint.z = -cameraTransform.position.z;
            var myStartPoint = new Vector3();
          myStartPoint.x = Ball.position.x;
          myStartPoint.y = Ball.position.y;
          tl.RenderLine(myStartPoint, currentPoint);

      }

      if (Input.GetMouseButtonUp(0) && hittable2) {
        var mousePosition = Input.mousePosition;
        mousePosition.z = -cameraTransform.position.z;
            endPoint = cam.ScreenToWorldPoint(mousePosition);
         endPoint.z = -cameraTransform.position.z;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
         rb.AddForce(force * power * -1, ForceMode2D.Impulse);
         tl.EndLine();
         hittable2 = false;

      }
   }

    private float checkDistance()
    {

        return Vector3.Distance(Ball.position, Gorilla.position);

    }
}

