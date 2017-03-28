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

   bool facingRight;

   // For Jumping
   bool grounded = false; // Character is starting off the ground, otherwise change to true
   Collider[] groundCollisions; // Holds anything that our ground check sphere collides with
   float groundCheckRadius = 0.2f;
   public LayerMask groundLayer;
   public Transform groundCheck;
   public float jumpHeight;

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

   }
    // When working with physics objects
   void FixedUpdate()
   {
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

      if (walking > 0)
      {
         myRig.velocity = new Vector3(move * walkSpeed, myRig.velocity.y, 0);
      }
      else
      {
         myRig.velocity = new Vector3(move * runSpeed, myRig.velocity.y, 0);
      }

      if (move > 0 && !facingRight)
      {
         Flip();
      }
      else if (move < 0 && facingRight)
      {
         Flip();
      }
   }

   void Flip()
   {
              facingRight          = !facingRight;
      Vector3 zedScale             = transform.localScale;
              zedScale.z          *= -1;
              transform.localScale = zedScale;
   }
}
