using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaController : MonoBehaviour
{
    [SerializeField] private Transform gorillaTransform;
    [SerializeField] private Rigidbody2D gorillaRigidbody;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private int moveSpeed;

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

        if (Input.GetKeyDown("w"))
        {
            gorillaRigidbody.AddForce(new Vector2(0, 600));

        }
        if (gorillaRigidbody.velocity.y < 0) // player is falling
        {
            Debug.Log("velocity is negative");
            gorillaRigidbody.gravityScale = 10;
        }
        else
        {
            gorillaRigidbody.gravityScale = 1;
        }
        Debug.Log(gorillaRigidbody.velocity.y);
    }

    //private IEnumerator amplifyGravity()
    //{
    //    //yield return new WaitForSeconds
    //}

}
