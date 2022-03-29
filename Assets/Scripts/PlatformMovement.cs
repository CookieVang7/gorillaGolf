using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Transform platformTransform;
    [SerializeField] private float peakPlatformHeight;
    [SerializeField] private float lowestPlatformHeight;
    [SerializeField] private Vector2 platformVectorSpeed;
    [SerializeField] private Rigidbody2D platformRigidBody2D;
    private bool platIsGoingUp = true;

    void Update() // moves a platform up and down, starting by going up
    {
        
        
    }
    private void FixedUpdate()
    {
        if (platIsGoingUp)
        {
            movePlatformUp();
        }
        else
        {
            movePlatformDown();
        }
    }
    private void movePlatformUp()
    {
        if (platformTransform.position.y >= peakPlatformHeight)
        {
            platIsGoingUp = false;
        }
        else
        {
            platformRigidBody2D.MovePosition(platformRigidBody2D.position + platformVectorSpeed * Time.deltaTime);
        }
    }

    private void movePlatformDown()
    {
        if (platformTransform.position.y <= lowestPlatformHeight)
        {
            platIsGoingUp = true;
        }
        else
        {
            platformRigidBody2D.MovePosition(platformRigidBody2D.position - platformVectorSpeed * Time.deltaTime);
        }
    }
}
