using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GorillaController : MonoBehaviour
{
    [SerializeField] private Transform gorillaTransform;
    [SerializeField] private Rigidbody2D gorillaRigidbody;
    [SerializeField] private Collider2D gorillaCollider;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private int moveSpeed;
    private GameObject collisionObject;
    private float playerCollisionDirection;
    private bool isOnGround;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private float verticalJumpForce;
    [SerializeField] private AudioSource gorillaNoise; // jump sfx
    [SerializeField] private AudioSource gorillaStomp; // movement sfx

    // New movement variables
    private float horizontalMovement;
    private float verticalMovement;
    private bool haveJump = true;
    private bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
        collisionObject = collision.gameObject;
        if (collision.gameObject.CompareTag("jumpReset") || collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            haveJump = true;
        }

       // if (collision.gameObject.CompareTag("wall") && gorillaRigidbody.velocity.y <= 0)
        //{
        //    gorillaRigidbody.gravityScale = 2.5f;
        //}

        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("jumpReset"))
        {
            isOnGround = true;
            if (Mathf.Abs(gorillaRigidbody.velocity.x) > 5 && !gorillaStomp.isPlaying)
            {
                gorillaStomp.Play();
            }
        } else
        {
            isOnGround = false;
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
        
        if (collision.gameObject.tag == "Ball")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gorillaCollider);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //gorillaRigidbody.gravityScale = 10;
        haveJump = false;
    }

    private void GorillaWallJump(float wallJumpForce)
    {
        // For Future reference: Make it able to detect tilemap collider2D? Instead of adding an extra hitbox
        if (gorillaTransform.position.x < collisionObject.transform.position.x
                    && gorillaTransform.position.y < (collisionObject.transform.position.y + collisionObject.GetComponent<Collider2D>().bounds.size.y / 2f) && !isOnGround && GorillaOnTheWall())
        {
            gorillaRigidbody.AddForce(new Vector2(-wallJumpForce, 0));
        }
        else if (gorillaRigidbody.position.x > collisionObject.transform.position.x
          && gorillaTransform.position.y < (collisionObject.transform.position.y + collisionObject.GetComponent<Collider2D>().bounds.size.y / 2f) && !isOnGround && GorillaOnTheWall())
        {
            gorillaRigidbody.AddForce(new Vector2(wallJumpForce, 0));
        }
    }

    private bool GorillaOnTheWall()
    {
        bool isOnWall = collisionObject != null && gorillaCollider.IsTouching(collisionObject.GetComponent<Collider2D>()) && collisionObject.CompareTag("wall");
        return isOnWall;
    }


}
