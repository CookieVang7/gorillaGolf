using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    [SerializeField] private float maxDistanceBallGorilla;
    [SerializeField] public float power = 10f;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private AudioSource ballAudioSource;
    [SerializeField] private GameObject escMenu;
    [SerializeField]
    public Vector2 minPower;
    public Vector2 maxPower;
    public Rigidbody2D rb;
    public Transform Ball;
    public Transform Gorilla;
    public Transform cameraTransform;
    bool hittable2 = false;
    Vector2 force;
    Vector3 startPoint;
    TrajectoryLine tl;
    Camera cam;
    static public bool closeToBall;
    SpriteRenderer ballRend;

    private void Start() {
        cam = FindObjectOfType<Camera>();
        tl = GetComponent<TrajectoryLine>();
        Counter.hitCount = 0;
        closeToBall = false;
        ballRend = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && OnMouseOverBall.hittable && Vector3.Distance(Ball.position, Gorilla.position) <= maxDistanceBallGorilla && !escMenu.activeInHierarchy )
        {
            hittable2 = true;
        }


        if (Vector3.Distance(Ball.position, Gorilla.position) <= maxDistanceBallGorilla)
        {
            closeToBall = true;
            ballRend.color = Color.green;
        }
        else {
            ballRend.color = Color.red;
            closeToBall = false;
         };

        if (Input.GetMouseButton(0) && hittable2 && !escMenu.activeInHierarchy) {
            var mousePosition = Input.mousePosition;
            mousePosition.z = -cameraTransform.position.z;
            Vector3 currentPoint = cam.ScreenToWorldPoint(mousePosition);
            currentPoint.z = -cameraTransform.position.z;
            startPoint.x = Ball.position.x;
            startPoint.y = Ball.position.y;
            startPoint.z = Ball.position.z;
            tl.RenderLine(startPoint, currentPoint);
      }

        if (Input.GetMouseButtonUp(0) && hittable2 && !escMenu.activeInHierarchy) {
            var endPoint = tl.getEndpoint();
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.AddForce(force * power * -1, ForceMode2D.Impulse);
            tl.EndLine();
            ballAudioSource.Play();
            hittable2 = false;
            Counter.hitCount++;
            gameUI.UpdateHitCount(Counter.hitCount);
      }
   }
}

