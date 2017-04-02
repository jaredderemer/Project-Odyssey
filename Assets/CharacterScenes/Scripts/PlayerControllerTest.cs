using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
   // Movement
   public float runSpeed;
   public float walkSpeed;

   Rigidbody myRig;
   Animator myAnim;

   [HideInInspector] public bool facingRight;
   private float attacking;

   // For Jumping
   [HideInInspector] public bool grounded = false; // Character is starting off the ground, otherwise change to true
   Collider[] groundCollisions; // Holds anything that our ground check sphere collides with
   float groundCheckRadius = 0.2f;
   public LayerMask groundLayer;
   public Transform groundCheck;
   public float jumpHeight;
	[HideInInspector] public bool pushed = false;
	private bool attacked = false;

   // Use this for initialization
   void Start()
   {
      myRig = GetComponent<Rigidbody>();
      myAnim = GetComponent<Animator>();
      facingRight = true;
   }

   // Update is called once per frame
   void Update()
   {
		//attacked = pushed; // Works with the tree but not with the monkey
   }
    // When working with physics objects
   void FixedUpdate()
   {
		attacked = pushed; // Works with the monkey but not with the tree
                         // But if both are done then neither work....???

      attacking = Input.GetAxisRaw("Fire1");
      myAnim.SetFloat("attacking", attacking);
      if ((attacking > 0) && (Input.GetAxisRaw("Fire1") > 0))
      {
         myAnim.SetFloat("attacking", attacking);
      }

      if (grounded && Input.GetAxisRaw("Jump") > 0)
      {
         grounded = false;
         myAnim.SetBool("grounded", grounded);
         myRig.AddForce(new Vector3(0, jumpHeight, 0));
      }

      groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
      if (groundCollisions.Length > 0)
      {
         grounded = true;
      }
      else
      {
         grounded = false;
      }

      myAnim.SetBool("grounded", grounded);

      float move = Input.GetAxis("Horizontal");
      myAnim.SetFloat("speed", Mathf.Abs(move));

      float walking = Input.GetAxisRaw("Fire3"); // Associated with Shift button
      myAnim.SetFloat("walking", walking);

		if (!attacked)
		{
			if (walking > 0)
			{
				myRig.velocity = new Vector3 (move * walkSpeed, myRig.velocity.y, 0);
			}
			else
			{
				myRig.velocity = new Vector3 (move * runSpeed, myRig.velocity.y, 0);
			}

			if (move > 0 && !facingRight)
			{
				Flip ();
			}
			else if (move < 0 && facingRight)
			{
				Flip ();
			}
			//Debug.Log ("attacked: " + attacked);
			//Debug.Log ("pushed: " + pushed);
		}
		else
		{
			myRig.velocity = new Vector3 (0, myRig.velocity.y, 0);

			//Debug.Log ("currentVelocity: " + myRig.velocity);
			//Debug.Log ("attacked: " + attacked);
			//Debug.Log ("pushed: " + pushed);
		}
   }

   void Flip()
   {
		gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, facingRight ? -100.0f : 100.0f, 0.0f));

		facingRight = !facingRight;
   }
}