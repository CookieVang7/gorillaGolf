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
    [SerializeField] private float wallJumpForce;
    [SerializeField] private GameUI gameUI;
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
    private RaycastHit2D bufferRightRay;
    private RaycastHit2D leftRay;
    private RaycastHit2D bufferLeftRay;
    private RaycastHit2D downRay;
    [SerializeField] private GameObject escMenu;


    void Start()
    {
        // This sets the variables to be approximately the length of half the gorilla collider with some adjustments
        rayCheckDistance =  gorillaCollider.bounds.extents.x;
        boxCheckDistance = gorillaCollider.bounds.extents.y - .3f;

        //This makes it so the gorilla's feet cannot touch the ball
        Physics2D.IgnoreCollision(ballCollider, gorillaCollider);

        //This is a check for each level to see if the music needs to change at the start
        GameObject.Find("Music(Clone)").GetComponent<MusicScript>().setMusic();
        

    }
    private static readonly int GORILLA_WALK = Animator.StringToHash("GorillaWalk");
    private static readonly int GORILLA_LEFTJUMP = Animator.StringToHash("GorillaWallLeft");
    private static readonly int GORILLA_RIGHTJUMP = Animator.StringToHash("GorillaWallRight");
    void Update()
    {
        // Ray casting / Box casting for conditionals like wall jumping and checking if the gorilla is on the ground
        // Ray casting casts a ray from a specified location to a specified direction/length and if an object collids with it, it becomes true
        rightRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)), rayCheckDistance +.3f, wallLayer);
        bufferRightRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)), rayCheckDistance + 1);
        leftRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)), rayCheckDistance, wallLayer);
        bufferLeftRay = Physics2D.Raycast(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)), rayCheckDistance + .7f);
        downRay = Physics2D.BoxCast(gorillaCollider.bounds.center, gorillaCollider.bounds.extents*2, 0f, gorillaTransform.TransformDirection(new Vector2(0, -1)), boxCheckDistance);

        // This is to help debug the rays. It creates a visual to see exactly how long and where the rays are comming from
        // Current: Checking the buffer ray lengths
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(1, 0)) * (rayCheckDistance + 1), Color.red);
        Debug.DrawRay(gorillaTransform.position, gorillaTransform.TransformDirection(new Vector2(-1, 0)) * (rayCheckDistance + .7f), Color.red);

        // This sets a variable to help create velocity under fixedUpdate to move the gorilla in a specified direction
        // It specifies the direction with Input.GetAxisRaw("Horizontal"), which equals -1 when inputting to the left (key: a)
        // and equals 1 when inputting to the right (key: d)
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float horizontal = Input.GetAxisRaw("Horizontal");
        //horizontalMovement = horizontal * moveSpeed;

        // This toggles our gorilla walk animation when the horizontal variable is either -1 or 1 (meaning they are moving)
        animator.SetBool(GORILLA_WALK, ( horizontal > 0 || horizontal < 0) && downRay) ;
        animator.SetBool(GORILLA_LEFTJUMP, bufferLeftRay && !downRay);
        animator.SetBool(GORILLA_RIGHTJUMP, bufferRightRay && !downRay);


        // This dictates the jump keys (space and w) and also checks to see if the bufferRays are within range
        // If the buffer rays are within range it will activate the "jumping" bool which will activate a jump
        // as soon as the corresponding "haveJump" bool is true. This makes it so the wall jumping / jumping input
        // is not so exact.
        if ((Input.GetKeyDown("w")) && (bufferRightRay || bufferLeftRay || downRay) || (Input.GetKeyDown("space") && (bufferRightRay || bufferLeftRay || downRay))) // player jump
        {
            jumping = true;
            StartCoroutine(jumpBuffer()); 
        }

        // This dictates the button used to access the main menu
        if (Input.GetKeyDown(KeyCode.Escape) && !Counter.isMenuOpen)
        {
            Time.timeScale = 0;
            escMenu.SetActive(true);
        }

        // This is the reset button
        if (Input.GetKeyDown("r") && !Counter.isMenuOpen)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Counter.deathCount++;
        }
        
        // This changes the animation layer when the Gorilla is close enough to the ball
        if (DragNShoot.closeToBall)
        {
           
            animator.SetLayerWeight(animator.GetLayerIndex("Smile Layer"), 1);
            animator.SetLayerWeight(animator.GetLayerIndex("Base Layer"), 0);
            
        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Smile Layer"), 0);
            animator.SetLayerWeight(animator.GetLayerIndex("Base Layer"), 1);
        }
    }

    private void FixedUpdate()
    {
        // This adds the horizontalMovement variable (declared above under Update()) to the gorilla's velocity
        gorillaRigidbody.AddForce(new Vector2(horizontalMovement * Time.deltaTime, 0));

        // This is adds jumping velocity to the gorilla. It has two jumping variables to implement a buffer (explained above)
        // and uses the method GorillaWallJump to figure out if the jump should have horizontal velocity added as well
        if (jumping && haveJump)
        {
            gorillaRigidbody.AddForce(new Vector2(0, verticalJumpForce));
            GorillaWallJump(wallJumpForce);
            jumping = false;
            haveJump = false;

            // Gorilla jump noise
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
        // Makes it so the gorilla gets a jump reset everytime his collider comes into contact with anything
        // other than the ball. This is also involved in the jump buffer explained above.
        if (!collision.gameObject.CompareTag("Ball"))
        {
            haveJump = true;
        }

        // This is the gorilla walking noise. It plays as long as he is not moving into a wall and if he is moving.
        if (!collision.gameObject.CompareTag("Ball") && !rightRay && !leftRay)
        {
            if (Mathf.Abs(gorillaRigidbody.velocity.x) > 5 && !gorillaStomp.isPlaying)
            {
                gorillaStomp.Play();
            }
        }

        // This is the math done to slow the gorilla down when he is pressing into a wall and falling.
        // It limits how fast his downward and upward velocity can be while pressing into a wall.
        if (GorillaOnTheWall() && horizontalMovement != 0)
        {
            //Debug.Log("gorilla velocity is: " + gorillaRigidbody.velocity.y);
            gorillaRigidbody.velocity = new Vector2(gorillaRigidbody.velocity.x, Mathf.Clamp(gorillaRigidbody.velocity.y, -1f, 50f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reloads the scene when colliding with a spike object (cacti) and increments death counters
        if (collision.gameObject.CompareTag("spike"))
        {
            Counter.deathCount++;
            gameUI.UpdateDeathCount();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    // Helps get rid of the gorilla's jump when he is no longer touching something
    private void OnCollisionExit2D(Collision2D collision)
    {
        haveJump = false;
    }
    // Method used in fixedUpdate() to help decide if the gorilla should be wall jumping instead
    // of vertical jumping
        private void GorillaWallJump(float wallJumpForce){
        if(rightRay && !downRay) {
            gorillaRigidbody.AddForce(new Vector2(-wallJumpForce, 0));
        } else if (leftRay && !downRay) {
            gorillaRigidbody.AddForce(new Vector2(wallJumpForce, 0));
        }
    }
    // Helps identify if the gorilla is just on a wall
    private bool GorillaOnTheWall()
    {
        bool isOnWall = (leftRay || rightRay) && !downRay;
        return isOnWall;
    }

    //Used above with the jumpBuffer rays and such
    // Waits .2 seconds before re declaring the jumping variable as false to keep from really
    // long input buffers
    IEnumerator jumpBuffer()
    {
        yield return new WaitForSeconds(.2f);
        jumping = false;
    }
}