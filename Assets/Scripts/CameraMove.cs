using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform CameraTransform;
    [SerializeField] float cameraX;
    [SerializeField] float cameraY;
    [SerializeField] float cameraZ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Gorilla")){
            Debug.Log("This is working");
            //collision.gameObject.GetComponent<Transform>().position = new Vector3(cameraX, cameraY, 0);
            CameraTransform.position = new Vector3(cameraX, cameraY, cameraZ);
        }
    }

}
