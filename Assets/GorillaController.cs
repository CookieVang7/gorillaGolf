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
    private int jumpCount = 1;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jumpReset"))
        {
            jumpCount = 1;
        }
    }
    }
