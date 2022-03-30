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
    private int jumpCount = 1;
    private float playerCollisionDirection;
    private bool isOnGround;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private float verticalJumpForce;
    [SerializeField] private AudioSource gorillaNoise;
    [SerializeField] private AudioSource gorillaStomp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
           // Debug.Log(-moveSpeed * Time.deltaTime);
            gorillaRigidbody.AddForce(new Vector2(-moveSpeed * Time.deltaTime, 0));

        }

        if (Input.GetKey("d"))
        {
            gorillaRigidbody.AddForce(new Vector2(moveSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown("w") && jumpCount == 1)
        {
            gorillaRigidbody.AddForce(new Vector2(0, verticalJumpForce));
            jumpCount = 0;
            gorillaNoise.Play();
            if (GorillaOnTheWall())
            {
                GorillaWallJump(wallJumpForce);
            }
        }  
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collisionObject = collision.gameObject;
        if (collision.gameObject.CompareTag("jumpReset") || collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            jumpCount = 1;
        }

       // if (collision.gameObject.CompareTag("wall") && gorillaRigidbody.velocity.y <= 0)
        //{
        //    gorillaRigidbody.gravityScale = 2.5f;
        //}

        if (collision.gameObject.CompareTag("ground"))
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
        jumpCount = 0;
    }

    private void GorillaWallJump(float wallJumpForce)
    {
        // For Future reference: Make it able to detect tilemap collider2D? Instead of adding an extra hitbox
        if (gorillaTransform.position.x < collisionObject.transform.position.x
                    && gorillaTransform.position.y < (collisionObject.transform.position.y + collisionObject.GetComponent<Collider2D>().bounds.size.y / 2f) && !isOnGround)
        {
            gorillaRigidbody.AddForce(new Vector2(-wallJumpForce, 0));
        }
        else if (gorillaRigidbody.position.x > collisionObject.transform.position.x
          && gorillaTransform.position.y < (collisionObject.transform.position.y + collisionObject.GetComponent<Collider2D>().bounds.size.y / 2f) && !isOnGround)
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
