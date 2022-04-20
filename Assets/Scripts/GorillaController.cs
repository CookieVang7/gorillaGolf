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
    [SerializeField] private Animator animator;
    [SerializeField] private int moveSpeed;
    private bool isOnGround;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private float verticalJumpForce;
    [SerializeField] private AudioSource gorillaNoise; // jump sfx
    [SerializeField] private AudioSource gorillaStomp; // movement sfx
    //[SerializeField] private DeathCounter deathCounter;
    

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
    private RaycastHit2D downRay;
    [SerializeField] private GameObject escMenu;
    void Start()
    {
        rayCheckDistance =  gorillaCollider.bounds.extents.x + .5f;
        boxCheckDistance = gorillaCollider.bounds.extents.y - .3f;
        Physics2D.IgnoreCollision(ballCollider, gorillaCollider);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TutorialLevel") && !MusicScript.firstTimeLevel1){
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(1);
            MusicScript.firstTimeLevel1 = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("JungleLevel2") && !MusicScript.firstTimeLevel1)
        {
            GameObject.Find("Music(Clone)").GetComponent<MusicScript>().playTrack(2);
            MusicScript.firstTimeLevel1 = true;
        }
    }
    private static readonly int GORILLA_WALK = Animator.StringToHash("GorillaWalk");
    void Update()
    {
        // Ray casting / Box casting for conditionals like wall jumping and isOnGround checks
        rightRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)), rayCheckDistance +.3f, wallLayer);
        leftRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)), rayCheckDistance, wallLayer);
        downRay = Physics2D.BoxCast(gorillaCollider.bounds.center, gorillaCollider.bounds.extents, 0f, gorillaTransform.TransformDirection(new Vector2(0, -1)), boxCheckDistance, wallLayer);
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)) * (rayCheckDistance + .3f), Color.red);
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)) * rayCheckDistance, Color.red);

        if (downRay){
            isOnGround = true;
        } else isOnGround = false;
        float horizontal = Input.GetAxisRaw("Horizontal");
        horizontalMovement = horizontal * moveSpeed;

        animator.SetBool(GORILLA_WALK, horizontal > 0 || horizontal < 0);

        

        if ((Input.GetKeyDown("w")) && (rightRay || leftRay || downRay) || (Input.GetKeyDown("space") && (rightRay || leftRay || downRay))) // player jump
        {

            jumping = true;
            StartCoroutine(jumpBuffer()); 
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            escMenu.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        gorillaRigidbody.AddForce(new Vector2(horizontalMovement * Time.deltaTime, 0));

        if (jumping && haveJump)
        {
            gorillaRigidbody.AddForce(new Vector2(0, verticalJumpForce));
            GorillaWallJump(wallJumpForce);
            jumping = false;
            haveJump = false;

            if (gorillaNoise.isPlaying) // play gorilla jump noise 
            {
                gorillaNoise.Stop();
                gorillaNoise.Play();
            }
            else gorillaNoise.Play();
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

            //Debug.Log("gorilla velocity is: " + gorillaRigidbody.velocity.y);
            gorillaRigidbody.velocity = new Vector2(gorillaRigidbody.velocity.x, Mathf.Clamp(gorillaRigidbody.velocity.y, -1f, 50f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("spike"))
        {
            DeathCounter.IncrementDeathCount();
            gameUI.UpdateDeathCount();
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

    IEnumerator jumpBuffer()
    {
        yield return new WaitForSeconds(.2f);
        jumping = false;
    }
}
