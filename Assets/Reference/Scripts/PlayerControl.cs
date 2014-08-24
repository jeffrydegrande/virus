using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.


	public float moveForce = 465f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 120f;				// The fastest the player can travel in the x axis.
	public float maxVerticalSpeed = 60f;
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.


	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.


	void Awake()
	{
		// Setting up references.
		// groundCheck = transform.Find("groundCheck");
		// anim = GetComponent<Animator>();
	}


	void Update()
	{
	}


	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		float vh = Input.GetAxis("Vertical");


		// The Speed animator parameter is set to the absolute value of the horizontal input.
		// anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed) {
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		}

		if (vh * rigidbody2D.velocity.y < maxVerticalSpeed) {
			rigidbody2D.AddForce(Vector2.up * vh * moveForce);
		}

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);


		if (Mathf.Abs (rigidbody2D.velocity.y) > maxVerticalSpeed) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Sign (rigidbody2D.velocity.y) * maxVerticalSpeed);
		}

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
