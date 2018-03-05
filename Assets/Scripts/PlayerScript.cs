using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBScript : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rBody;
    private SpriteRenderer rRend;

    public float maxSpeed = 5f;
    public float jumpForce = 30;
    public Transform groundCheck;
    public LayerMask defineGround;  // defined layer, like Floor

    public int inputChannel = 0;

    private float speed, vSpeed;
    private bool isOnGround = false;
    private float groundRadius = 1f;

    
    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetAxis("Jump") > 0 && isOnGround)
  //      {
  //          isOnGround = false;
  //          animator.SetBool("isOnGround", isOnGround);
  //          rBody.AddForce(new Vector2(0, jumpForce));
  //      }
	}

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);

        animator.SetBool("isOnGound", isOnGround);
        animator.SetFloat("vSpeed", rBody.velocity.y);
        float moveHoriz = Input.GetAxis("Horizontal");
        //switch (inputChannel)
        //{
        //    case 1:
        //        moveHoriz = Input.GetAxis("Horizontal");
        //        break;
        //    case 2:
        //        moveHoriz = Input.GetAxis("Horizontal2");
        //        break;
        //    case 3:
        //        moveHoriz = Input.GetAxis("Horizontal3");
        //        break;
        //    default:
        //        break;
        //}

        //Debug.Log("isOnGround=" + isOnGround + " speed=" + Mathf.Abs(moveHoriz));

        animator.SetFloat("speed", Mathf.Abs(moveHoriz));
        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);

        if (moveHoriz > 0)
        {
            rRend.flipX = false;
        }
        else if (moveHoriz < 0)
        {
            rRend.flipX = true;
        }
    }
}
