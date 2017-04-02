using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

   // Movement variables
   public float runSpeed;
   public float sprintSpeed;

   Rigidbody myRB;
   Animator myAnim;

   [HideInInspector] public bool facingRight;

   // for jumping
   // Character is starting slightly off the ground, otherwise change to TRUE
   [HideInInspector] public bool grounded = false;
   Collider[] groundCollisions;
   float groundCheckRadius = 0.2f;
   public LayerMask groundLayer;
   public Transform groundCheck;
   public float jumpHeight;
   
	private Vector3 spawnPosition = Vector3.zero;
   
   [HideInInspector] public bool onWall = false;

   // Use this for initialization
   void Start()
   {
      myRB = GetComponent<Rigidbody>();
      myAnim = GetComponent<Animator>();
      facingRight = true;
      
      // Save starting position for respawn
		//spawnPosition = myRB.position;
   }

   // Update is called once per frame
   void Update()
   {
		if (globalController.Instance.currentSceneIndex > 2 && globalController.Instance.currentSceneIndex <= 5)
		{
			if (spawnPosition != globalController.Instance.spawnpoints [globalController.Instance.currentSceneIndex])
			{
				spawnPosition = globalController.Instance.spawnpoints [globalController.Instance.currentSceneIndex];
			}
		}
   }

   private void FixedUpdate()
   {
      // Check if the player jumps
      if (grounded && Input.GetAxis("Jump") > 0)
      {
         grounded = false;
         myAnim.SetBool("grounded", grounded);
         myRB.AddForce(new Vector3(0, jumpHeight, 0));
      }
      
      groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);

      // Check for grounded player
      if (groundCollisions.Length > 0)
         grounded = true;
      else
         grounded = false; 

      myAnim.SetBool("grounded", grounded);

      float move = Input.GetAxis("Horizontal");
      myAnim.SetFloat("speed", Mathf.Abs(move));

      // Do we need this???
      //myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);

      float sprinting = Input.GetAxisRaw("Fire3");
      myAnim.SetFloat("sprinting", sprinting);
      
      
      
      
      
      //Debug.Log("onWall == " + onWall);
      
     // Check if player is on wall
      if(!onWall || grounded)
      {
         
         if (sprinting > 0 && grounded)
         {
            myRB.velocity = new Vector3(move * sprintSpeed, myRB.velocity.y, 0);
         }
         else
         {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
         }
      }
      else if(grounded &&  onWall)
      {
         // Stop movement
         //myRB.velocity = new Vector3(0, .04f, 0);
         myRB.AddForce(new Vector3(0, -1.0f, 0));
         Debug.Log("Adding force down");
      }
      
      // Player uses a coconut!!!
      if (Input.inputString == "c")
      {

         this.GetComponent<playerAttacks>().rangeAttack();
         //gameObject<playerAttacks>().rangeAttack();
      }
      
      


      /*if (sprinting > 0 && grounded)
      {
         myRB.velocity = new Vector3(move * sprintSpeed, myRB.velocity.y, 0);
      }
      else
      {
         myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
      }*/

      if (move > 0 && !facingRight)
         Flip();
      else if (move < 0 && facingRight)
         Flip();
   }

   public void Flip()
   {
      facingRight = !facingRight;
      Vector3 zedScale = transform.localScale;
      zedScale.z *= -1;
      transform.localScale = zedScale;
   }
   
   // Respawn player to starting position in scene
   public void RespawnPlayer()
   {
		Debug.Log ("Respawn" + spawnPosition);
      myRB.position = spawnPosition;

		if (!facingRight)
		{
			Flip ();
		}
   }
}
