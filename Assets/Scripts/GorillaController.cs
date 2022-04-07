using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GorillaController : MonoBehaviour
{
    [SerializeField] private Transform gorillaTransform;
    [SerializeField] private Rigidbody2D gorillaRigidbody;
    [SerializeField] private Collider2D gorillaCollider;
    [SerializeField] private Collider2D ballCollider;
    [SerializeField] private int moveSpeed;
    private bool isOnGround;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private float verticalJumpForce;
    [SerializeField] private AudioSource gorillaNoise; // jump sfx
    [SerializeField] private AudioSource gorillaStomp; // movement sfx

    // New movement variables
    private float horizontalMovement;
    private bool haveJump = true;
    private bool jumping = false;

    // rayCasting instances / variables
    private float rayCheckDistance; // Created on start()
    private float boxCheckDistance;
    public LayerMask wallLayer;
    private RaycastHit2D rightRay;
    private RaycastHit2D leftRay;
    private RaycastHit2D downRay; // Maybe a solution for the checking isOnGround
    [SerializeField] private GameObject escMenu;
    void Start()
    {
        rayCheckDistance =  gorillaCollider.bounds.extents.x + .1f;
        boxCheckDistance = gorillaCollider.bounds.extents.y - .5f;
        Physics2D.IgnoreCollision(ballCollider, gorillaCollider);
    }

    // Update is called once per frame
    void Update()
    {
        //Boxcast is also a thing, but I kind 
        rightRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)), rayCheckDistance, wallLayer);
        //rightRay = Physics2D.BoxCast(gorillaCollider.bounds.center, gorillaCollider.bounds.extents, 0f, gorillaTransform.TransformDirection(new Vector2(1, 0)), rayCheckDistance, wallLayer);
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)) * rayCheckDistance, Color.red);
        leftRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)), rayCheckDistance, wallLayer);
        //leftRay = Physics2D.BoxCast(gorillaCollider.bounds.center, gorillaCollider.bounds.extents, 0f, gorillaTransform.TransformDirection(new Vector2(-1, 0)), rayCheckDistance, wallLayer);
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)) * rayCheckDistance, Color.red);
        downRay = Physics2D.BoxCast(gorillaCollider.bounds.center, gorillaCollider.bounds.extents, 0f, gorillaTransform.TransformDirection(new Vector2(0, -1)), boxCheckDistance, wallLayer);
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(0, -1)) * boxCheckDistance, Color.red); // This doesn't represent the boxCast by any means
        if (downRay){
            isOnGround = true;
        } else isOnGround = false;

        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetKeyDown("w") && haveJump) // player jump
        {

            jumping = true;
            haveJump = false;
        }
    }

    private void FixedUpdate()
    {

        //Debug.Log(horizontalMovement * Time.deltaTime); 
     gorillaRigidbody.AddForce(new Vector2(horizontalMovement * Time.deltaTime, 0));

        if(jumping)
        {
            gorillaRigidbody.AddForce(new Vector2(0, verticalJumpForce));
            GorillaWallJump(wallJumpForce);
            jumping = false;
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
        {
            haveJump = true;
        }

        if (!collision.gameObject.CompareTag("Ball") && !rightRay && !leftRay)
        {
            if (Mathf.Abs(gorillaRigidbody.velocity.x) > 5 && !gorillaStomp.isPlaying)
            {
                gorillaStomp.Play();
            }
        }

        if (GorillaOnTheWall() && horizontalMovement != 0)
        {

            Debug.Log("gorilla velocity is: " + gorillaRigidbody.velocity.y);
            gorillaRigidbody.velocity = new Vector2(gorillaRigidbody.velocity.x, Mathf.Clamp(gorillaRigidbody.velocity.y, -1f, 50f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        haveJump = false;
    }

        private void GorillaWallJump(float wallJumpForce){
        if(rightRay && !isOnGround) {
            gorillaRigidbody.AddForce(new Vector2(-wallJumpForce, 0));
        } else if (leftRay && !isOnGround) {
            gorillaRigidbody.AddForce(new Vector2(wallJumpForce, 0));
        }
    }

    private bool GorillaOnTheWall()
    {
        bool isOnWall = (leftRay || rightRay) && !downRay;
        return isOnWall;
    }


}
