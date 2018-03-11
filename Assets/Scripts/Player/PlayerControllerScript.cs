using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {
    private Animator playerAnimator;   // player animater
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;
    
   
    public float maxSpeed = 5f;
    public float jumpForce = 200;
    public Transform groundCheck;
    public LayerMask defineGround;  // defined layer, like Floor
    private float speed, vSpeed;
    public bool isOnGround = false;
    private float groundRadius = 0.1f;

    public bool isDoubleJumpAllowed = true;
    private bool isOnFirstJump = false;
    private bool isSecondJump = false;
    private float DelayTimer = 0F;
    private float WaitTime = 1F;


    // Use this for initialization
    void Start () {

        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log("Grounded? " + isOnGround/* + " Groundcheck: " + groundCheck*/);
    }
	
	// Update is called once per frame
	void Update () {

        //isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);

        if (Input.GetKeyUp("space"))
        {
            //if (isOnFirstJump) isSecondJump = true;
            //if (!isOnFirstJump) isOnFirstJump = true;
            if (isOnFirstJump && Time.time > DelayTimer)
            {
                //print("second");
                isSecondJump = true;
            }

            if (!isOnFirstJump && Time.time > DelayTimer)
            {
                //print("first");
                isOnFirstJump = true;
            }

            DelayTimer -= Time.time + WaitTime;
        }


        //if (Input.GetAxis("Jump") > 0 && isOnGround && vSpeed == 0)
        //{
        //    isOnGround = false;
        //    playerAnimator.SetBool("isOnGround", isOnGround);
        //    playerRigidbody.AddForce(new Vector2(0, jumpForce));
        //    Debug.Log("Grounded? " + isOnGround/* + " Groundcheck: " + groundCheck*/);

        //}
        //else
        //{
        //    isOnGround = true;
        //    playerAnimator.SetBool("isOnGround", isOnGround);
        //}
    }
    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);
        //Debug.Log("Grounded? " + isOnGround/* + " Groundcheck: " + groundCheck*/);


        if (isOnGround)
        {
            isOnFirstJump = false;
            isSecondJump = false;
        }


        if (Input.GetAxis("Jump") > 0 && vSpeed == 0)
        {
            if (isOnGround)
            {
                isOnGround = false;
                playerAnimator.SetBool("isOnGround", isOnGround);
                playerRigidbody.AddForce(new Vector2(0, jumpForce));
            }
    
            if (isSecondJump)
            {
                isSecondJump = false;
                isOnFirstJump = false;
                DelayTimer -= Time.time + WaitTime;

               // Debug.ClearDeveloperConsole();
                playerRigidbody.AddForce(new Vector2(0, jumpForce));
            }
        }
        else
        {
            isOnGround = true;
             //playerAnimator.SetBool("isOnGround", isOnGround);
        }

        playerAnimator.SetBool("isOnGround", isOnGround);
        playerAnimator.SetFloat("vSpeed", playerRigidbody.velocity.y);
        Debug.Log("vSp=" + vSpeed + ", sp=" + speed + ", isOnG=" + isOnGround);
        float moveHoriz = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("speed", Mathf.Abs(moveHoriz));

        playerRigidbody.velocity = new Vector2(moveHoriz * maxSpeed, playerRigidbody.velocity.y);

        if (moveHoriz > 0)
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (moveHoriz < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
    }
}
