using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            gorillaRigidbody.AddForce(new Vector2(0, 1500));
            jumpCount = 0;
        }
        if (collisionObject != null && gorillaCollider.IsTouching(collisionObject.GetComponent<Collider2D>()) && collisionObject.CompareTag("wall") && Input.GetKeyDown("w"))
        {
            // bounds.size.y seems to take into account transform position. Changing to just this is getting the proper height of the wall.
            
            if (gorillaTransform.position.x < collisionObject.transform.position.x 
                && gorillaTransform.position.y < collisionObject.GetComponent<Collider2D>().bounds.size.y)
            {
                gorillaRigidbody.AddForce(new Vector2(-1500, 0));
            } else if (gorillaRigidbody.position.x > collisionObject.transform.position.x
                && gorillaTransform.position.y < collisionObject.GetComponent<Collider2D>().bounds.size.y)
            {
                gorillaRigidbody.AddForce(new Vector2(1500, 0));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionObject = collision.gameObject;
        playerCollisionDirection = gorillaRigidbody.velocity.x;
        Debug.Log(playerCollisionDirection);
        if (collision.gameObject.CompareTag("jumpReset"))
        {
            jumpCount = 1;
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            jumpCount = 1;
            gorillaRigidbody.gravityScale = 2.5f;
        }
        if (Input.GetKeyDown("w") && jumpCount == 1)
        {
            gorillaRigidbody.AddForce(new Vector2(-1500, 0));
            jumpCount = 0;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        gorillaRigidbody.gravityScale = 10;
    }
}
