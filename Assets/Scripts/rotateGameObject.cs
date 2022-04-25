using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// rotates the game object the script is attached to back and forth along the z-axis between the input angles

public class rotateGameObject : MonoBehaviour
{
    [SerializeField] private bool rotatingTowardStart = false;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, Mathf.PingPong(Time.time * rotationSpeed, 90) - 90);
        Debug.Log(transform.rotation.z);
    }
}
