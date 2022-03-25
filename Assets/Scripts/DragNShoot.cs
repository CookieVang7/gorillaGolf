using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 15;
            
            startPoint = cam.ScreenToWorldPoint(mousePosition);
            startPoint.z = 15;
            Debug.Log("Below is startpoint");
            Debug.Log(startPoint);
        }
if (Input.GetMouseButtonUp(0)) {
         var mousePosition = Input.mousePosition;
         mousePosition.z = 15;
         endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
         endPoint.z = 15;
         Debug.Log("This is endpoint");
         Debug.Log(endPoint);

         force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
         Debug.Log(force);
         rb.AddForce(force * power, ForceMode2D.Impulse);
        
}
        
    }
}
