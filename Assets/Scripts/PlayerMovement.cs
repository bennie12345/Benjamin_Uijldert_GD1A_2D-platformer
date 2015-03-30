using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float movementSpeed;
	private Animator anim; 
	private Animator animator;
	private Rigidbody2D rb2d;
	private bool isGrounded = true;
	public bool jump = false;    // Condition for whether the player should jump.
	public float jumpForce = 1000f;   // Amount of force added when the player jumps.
	
	private ParallaxController _parallaxController;
	
	void Awake()
	{
		_parallaxController = GetComponent<ParallaxController>();
		animator = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (x, 0f);
		transform.Translate (movement * movementSpeed * Time.deltaTime);
		_parallaxController.Scroll (movement *= -1);
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
		
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.Space)) {
			if (!jump && isGrounded == true)
			{
				jump = true;
			}
		}
		
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			Vector3 theScale = transform.localScale;
			theScale.x = 2f;
			transform.localScale = theScale;
			
			animator.Play("running");
		} 
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
		{
			Vector3 theScale = transform.localScale;
			theScale.x = -2f;
			transform.localScale = theScale;
			
			animator.Play ("running");
		} 
		else 
		{
			animator.Play ("idle");
			
		}
		// If the player should jump...
		if(jump)
		{ 
			if(isGrounded){
				rb2d.AddForce(new Vector2(0f, jumpForce));
				
				// Make sure the player can't jump again until the jump conditions from Update are satisfied.
				jump = false;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
        if (col.gameObject.tag == "Gameover")
        {
            Application.LoadLevel("platformer");
            
        }
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
			
		}
	}
	
}