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
            gorillaRigidbody.AddForce(new Vector2(0, 1500));

        }
    }
}
