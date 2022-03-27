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
    float playerCollisionDirection;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private float verticalJumpForce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            gorillaTransform.position = gorillaTransform.position + new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            gorillaTransform.position = gorillaTransform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("w") && jumpCount == 1)
        {
            gorillaRigidbody.AddForce(new Vector2(0, verticalJumpForce));
            jumpCount = 0;
            if (GorillaOnTheWall())
            {
                GorillaWallJump(wallJumpForce);
            }
        }  
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collisionObject = collision.gameObject;
        if (collision.gameObject.CompareTag("jumpReset"))
        {
            jumpCount = 1;
        }

        if (collision.gameObject.CompareTag("wall") && gorillaRigidbody.velocity.y <= 0)
        {
            jumpCount = 1;
            gorillaRigidbody.gravityScale = 2.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            Debug.Log("quack");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gorillaRigidbody.gravityScale = 10;
        jumpCount = 0;
    }

    private void GorillaWallJump(float wallJumpForce)
    {
        if (gorillaTransform.position.x < collisionObject.transform.position.x
                    && gorillaTransform.position.y < (collisionObject.transform.position.y + collisionObject.GetComponent<Collider2D>().bounds.size.y / 2f))
        {
            gorillaRigidbody.AddForce(new Vector2(-wallJumpForce, 0));
        }
        else if (gorillaRigidbody.position.x > collisionObject.transform.position.x
          && gorillaTransform.position.y < (collisionObject.transform.position.y + collisionObject.GetComponent<Collider2D>().bounds.size.y / 2f))
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
