using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {
    private Animator playerAnimator;   // player animater
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;

    public float maxSpeed = 5f;
    public float jumpForce = 30;
    public Transform groundCheck;
    public LayerMask defineGround;  // defined layer, like Floor

    private float speed, vSpeed;
    private bool isOnGround = false;
    private float groundRadius = 1f;


    // Use this for initialization
    void Start () {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Jump") > 0 && isOnGround)
        {
            isOnGround = false;
            playerAnimator.SetBool("isOnGround", isOnGround);
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);

        playerAnimator.SetBool("isOnGound", isOnGround);
        playerAnimator.SetFloat("vSpeed", playerRigidbody.velocity.y);
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
