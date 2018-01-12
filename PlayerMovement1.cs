using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour {

    //private Rigidbody2D rb2d;
    public bool onLadder = false;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityScale;
	private float gravityStore; 
	public Vector2 jump;
	public float jumpForce = 1.0f;
	public float speed= 10;
	public bool jumpBool = false;
	public Transform groundCheck; 
	public int jumpAmount = 0; 
	public bool HammerOn = false; 
	public bool isGrounded = false; 
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//jump = new Vector2(0.0f, 1.0f);
	}

	void Update() {

		if(jumpAmount == 0)
		{
			if(Input.GetButtonDown("Jump"))
			{
				//jumpBool = true; 
				rb.AddForce (Vector2.up * jumpForce);
				isGrounded = false;
				jumpAmount++; 
			}
		}

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector2(180, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector2(180, 180);
        }
    }

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0.0f);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		isGrounded = true;
		jumpAmount = 0;

    }
}
