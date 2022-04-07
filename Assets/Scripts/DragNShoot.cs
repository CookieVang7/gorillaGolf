using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    [SerializeField] private float maxDistanceBallGorilla;
    [SerializeField] public float power = 10f;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private AudioSource ballAudioSource;
    [SerializeField]
    public Vector2 minPower;
    public Vector2 maxPower;
    public Rigidbody2D rb;
    public Transform Ball;
    public Transform Gorilla;
    public Transform cameraTransform;
    bool hittable2 = false;
    public static int hitCount;
    Vector2 force;
    Vector3 startPoint;
    TrajectoryLine tl;
    Camera cam;

    private void Start() {
        cam = FindObjectOfType<Camera>();
        tl = GetComponent<TrajectoryLine>();
        hitCount = 0;
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
            var mousePosition = Input.mousePosition;
            mousePosition.z = -cameraTransform.position.z;
            Vector3 currentPoint = cam.ScreenToWorldPoint(mousePosition);
            currentPoint.z = -cameraTransform.position.z;
            var myStartPoint = new Vector3();
            myStartPoint.x = Ball.position.x;
            myStartPoint.y = Ball.position.y;
            myStartPoint.z = Ball.position.z;
            tl.RenderLine(myStartPoint, currentPoint);
      }

        if (Input.GetMouseButtonUp(0) && hittable2) {
            var endPoint = tl.getEndpoint();
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power * -1, ForceMode2D.Impulse);
            tl.EndLine();
            ballAudioSource.Play();
            hittable2 = false;
            hitCount++;
            gameUI.UpdateHitCount(hitCount);
      }
   }
}

