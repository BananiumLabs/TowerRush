using UnityEngine;
using System.Collections;

//SUMMARY: Allows player to move around
public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	private bool isJumping = false;
	public float jumpSpeed = 0.3f;
	private double currJump = 0;
	public double allowedJump = 1;
	float distToGround;
	private bool isGrounded;

	void Start () {
		
		distToGround = GetComponent<Collider>().bounds.extents.y;

		rb = GetComponent<Rigidbody> ();
	}

	void Update () {

		//Checks if player is touching ground
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

		//Resets current jump counter
		if (isGrounded)
			currJump = 0;

		//When space key pressed
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isJumping = true;

			Jump();
		}

		//Continue jumping if not complete
		if (isJumping && !isGrounded)
		{
			Jump();
		}
	}

	// Called before every physics calculation
	void FixedUpdate() {
		//Forward/backward/left/right
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (-moveHorizontal, 0.0f, -moveVertical); 
		rb.transform.Translate (force * speed);

	}

	//Allows player to jump
	public void Jump()
	{

		if (currJump < allowedJump)
		{
			float temp = 0.0f;
			temp = Mathf.Sin(Time.smoothDeltaTime) * jumpSpeed;
			currJump += temp;
			rb.velocity = (Vector3.up * temp * jumpSpeed);
		}
		else
		{
			isJumping = false;
		}
	}
		
}
