using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    [SerializeField]
    private float maxDistanceBallGorilla;
    [SerializeField]
    private float radius = 20f;
    public float power = 10f;
    public Rigidbody2D rb;
    public Transform Ball;
    public Transform Gorilla;
    [SerializeField] private GameUI gameUI;

    [SerializeField] private AudioSource ballAudioSource;
    [SerializeField] 

    public Vector2 minPower;
    public Vector2 maxPower;
    TrajectoryLine tl;
    Camera cam;
    public Transform cameraTransform;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    bool hittable2 = false;
    public static int hitCount;

        private void Start() {
        cam = FindObjectOfType<Camera>();
        tl = GetComponent<TrajectoryLine>();
        hitCount = 0;
        //Cursor.visible = true;
    }

    private void Update() {
       if (Input.GetMouseButtonDown(0) && OnMouseOverBall.hittable && Vector3.Distance(Ball.position, Gorilla.position) <= maxDistanceBallGorilla) {
           hittable2 = true;
           var mousePosition = Input.mousePosition;
           mousePosition.z = -cameraTransform.position.z;
           startPoint = cam.ScreenToWorldPoint(mousePosition);
           startPoint.z = -cameraTransform.position.z;
       }
      
      if (Input.GetMouseButton(0) && hittable2) {
          //Cursor.visible = false;
          var mousePosition = Input.mousePosition;
            //Debug.Log("Mouse Position: " + mousePosition);
          mousePosition.z = -cameraTransform.position.z;
          Vector3 currentPoint = cam.ScreenToWorldPoint(mousePosition);
           // Debug.Log("Current Point: " + currentPoint);
          currentPoint.z = -cameraTransform.position.z;
          var myStartPoint = new Vector3();
          myStartPoint.x = Ball.position.x;
          myStartPoint.y = Ball.position.y;
            myStartPoint.z = Ball.position.z;
           /* Vector3 ballCenter = Ball.position;
            float distance = Vector3.Distance(currentPoint, ballCenter);
            if (distance > radius)
            {
                currentPoint = Vector3.ClampMagnitude(currentPoint, radius);
                Debug.Log("Current Point Clamped: " + currentPoint);
                Vector3 fromOriginToObject = currentPoint - ballCenter;
                fromOriginToObject *= radius / distance;
                currentPoint = ballCenter + fromOriginToObject;
                tl.RenderLine(myStartPoint, currentPoint);
            }*/
            tl.RenderLine(myStartPoint, currentPoint);

      }

      if (Input.GetMouseButtonUp(0) && hittable2) {
        //   var mousePosition = Input.mousePosition;
        //   mousePosition.z = -cameraTransform.position.z;
        //  endPoint = cam.ScreenToWorldPoint(mousePosition);
        //  endPoint.z = -cameraTransform.position.z;

        var endPoint = tl.getEndpoint();

         force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            // reset ball velocity before applying force
            Ball.SetParent(null);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;

            Debug.Log(rb.velocity);
            
         rb.AddForce(force * power * -1, ForceMode2D.Impulse);
         tl.EndLine();
         ballAudioSource.Play();
         hittable2 = false;

         hitCount++;
         
         Cursor.visible = true;
         gameUI.UpdateHitCount(hitCount);

      }
   }

    private float checkDistance()
    {

        return Vector3.Distance(Ball.position, Gorilla.position);

    }
}

