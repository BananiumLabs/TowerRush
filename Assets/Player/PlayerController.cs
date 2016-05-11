using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	private bool isJumping = false;
	public float jumpSpeed = 0.3f;
	private double currJump = 0;
	public double allowedJump = 1;
	float distToGround;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		
		distToGround = GetComponent<Collider>().bounds.extents.y;

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

		if (isGrounded)
			currJump = 0;
		
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isJumping = true;

			Jump();
		}

		if (isJumping && !isGrounded)
		{
			Jump();
		}
	}

	// Called before every physics calculation
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 force = new Vector3 (-moveHorizontal, 0.0f, -moveVertical); 
		rb.transform.Translate (force * speed);

	}

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
