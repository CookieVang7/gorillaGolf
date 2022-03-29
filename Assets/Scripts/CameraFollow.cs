using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform mainTransform;
    [SerializeField] private Transform target;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = mainTransform.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(mainTransform.position, target.position, ref velocity, 0.15f);
        currentPosition.x = smoothPosition.x;
        currentPosition.y = smoothPosition.y;
        mainTransform.position = currentPosition;
    }
}
