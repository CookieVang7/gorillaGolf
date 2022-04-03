using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script moves a platform from between the start and end points. To use this you should place the
// platform at either the start or end position. These positions should be occupied by empty gane objects.

public class PlatformMover : MonoBehaviour
{

    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform platformTransform;
    [SerializeField] private float speed;
    [SerializeField] private bool movingTowardsStart = false;

    void Update()
    {

        float step = speed * Time.deltaTime;

        // check to see if the platform needs to change target
        if (Vector3.Distance(platformTransform.position, startPosition.position) <= .01f)
        {
            movingTowardsStart = false;
        }
        else if (Vector3.Distance(platformTransform.position, endPosition.position) <= .01f)
        {
            movingTowardsStart = true;
        }

        // toggle platform direction
        if (movingTowardsStart)
        {
            platformTransform.position = Vector3.MoveTowards(platformTransform.position, startPosition.position, step);
        }
        else 
        {
            platformTransform.position = Vector3.MoveTowards(platformTransform.position, endPosition.position, step);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // give entities the platform move speed by making the colliding objects a child of the platform
        collision.gameObject.transform.SetParent(this.gameObject.transform);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // undo parenting so their positions are unrelated
        collision.gameObject.transform.SetParent(null);
    }

}
