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
   private bool swingAttacking;
   private bool throwAttacking;

   // For Jumping
   [HideInInspector] public bool grounded = false; // Character is starting off the ground, otherwise change to true
   Collider[] groundCollisions; // Holds anything that our ground check sphere collides with
   float groundCheckRadius = 0.2f;
   public LayerMask groundLayer;
   public Transform groundCheck;
   public float jumpHeight;
	[HideInInspector] public bool pushed = false;
	private bool attacked = false;

	private Vector3 spawnPosition = Vector3.zero;

	[HideInInspector] public bool onWall = false;

	private float throwTimer;
	private float throwCooldown = .2f;

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
//		if (globalController.Instance.currentSceneIndex > 2 && globalController.Instance.currentSceneIndex <= 5)
//		{
//			if (spawnPosition != globalController.Instance.spawnpoints [globalController.Instance.currentSceneIndex])
//			{
//				spawnPosition = globalController.Instance.spawnpoints [globalController.Instance.currentSceneIndex];
//
//				// keeps the player from respawning into the cave if he dies before reaching the cave
//				// he will simply respawn in front of the hut
//				if (globalController.Instance.currentSceneIndex == 3 && myRig.transform.position.x < spawnPosition.x)
//				{
//					spawnPosition = new Vector3 (0.0f, 0.5f, gameObject.transform.position.z);
//				}
//				if (globalController.Instance.currentSceneIndex == 4 && myRig.transform.position.x < spawnPosition.x && myRig.transform.position.x > -23.0f)
//				{
//					spawnPosition = new Vector3 (-23.0f, -2.5f, gameObject.transform.position.z);
//				}
//			}
//		}
//		else if (globalController.Instance.currentSceneIndex == 6) // Possible index of horde scene?
//		{
//			spawnPosition = globalController.Instance.hordeSpawnpoint.position;
//		}
   }
    // When working with physics objects
   void FixedUpdate()
   {
		attacked = pushed;

      // THIS SECTION WAS MY OWN, GETTING FURTHER REFERENCE AS OF 00:36, 4 APRIL 2017
      //swingAttacking = Input.GetAxisRaw("Fire1").Equals(true);
      //myAnim.SetBool("swingAttacking", swingAttacking);
      //if ((swingAttacking) && (Input.GetAxisRaw("Fire1") > 0))
      //{
      //   myAnim.SetBool("swingAttacking", swingAttacking);
      //   // Call or write swing code here?
      //}

      //throwAttacking = Input.GetAxisRaw("Fire2").Equals(true);
      //myAnim.SetBool("throwAttacking", throwAttacking);
      //if ((throwAttacking) && (Input.GetAxisRaw("Fire2") > 0))
      //{
      //   myAnim.SetBool("throwAttacking", throwAttacking);
      //   // Call or write throw code here?
      //}

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

			// Check if player is on wall
			if(!onWall || grounded && onWall)
			{
				if (walking > 0)
            {
               myRig.velocity = new Vector3 (move * walkSpeed, myRig.velocity.y, 0);
            }
            else
            {
               myRig.velocity = new Vector3 (move * runSpeed, myRig.velocity.y, 0);
            }
			}
			else if(onWall)
			{
				// Stop movement
				//myRB.velocity = new Vector3(0, .04f, 0);
				myRig.AddForce(new Vector3(0, -1.0f, 0));
				Debug.Log("Adding force down");
			}

		}
		else
		{
			myRig.velocity = new Vector3 (0, myRig.velocity.y, 0);

			//Debug.Log ("currentVelocity: " + myRig.velocity);
			//Debug.Log ("attacked: " + attacked);
			//Debug.Log ("pushed: " + pushed);
		}

		// Keep track of time since last coconut throw
		throwTimer += Time.deltaTime;

		// Player uses a coconut!!!
		if (Input.GetKeyDown(KeyCode.C) && throwTimer >= throwCooldown)
		{
			this.GetComponent<playerAttacks>().rangeAttack();
			throwTimer = 0.0f;
		}

   }

   void Flip()
   {
		gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, facingRight ? -100.0f : 100.0f, 0.0f));

		facingRight = !facingRight;
	}

	// Respawn player to starting position in scene
	public void RespawnPlayer()
	{
		Debug.Log ("Respawn" + spawnPosition);
		myRig.position = spawnPosition;

		if (!facingRight)
		{
			Flip ();
		}
	}
}