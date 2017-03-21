using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
// Public variables
   // movingment variables
   public float      runSpeed;
   public float      walkSpeed;

   // Jumping variables
   public LayerMask  groundLayer;
   public Transform  groundCheck;
   public float      jumpHeight;

// Private Variables
   // Character Control
   private Rigidbody myRig;
   private Animator  myAnim;

   // Character Direction
   private bool      facingRight;

   // for jumping
   private bool       grounded = false; // Character is starting off the ground, otherwise change to TRUE
   private Collider[] groundCollisions;
   private float      groundCheckRadius = 0.2f;

   // Use this for initialization
   void Start()
   {
      myRig       = GetComponent<Rigidbody>();
      myAnim      = GetComponent<Animator> ();
      facingRight = true;
   }

   // Using FixedUpdate() for physics' sake
   void FixedUpdate()
   {
      groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);

      if (grounded && Input.GetAxis("Jump") > 0)
      {
         grounded = false;
         myAnim.SetBool("grounded", grounded);
         myRig.AddForce(new Vector3(0, jumpHeight, 0));
      }

      // Character on ground?
      if (groundCollisions.Length > 0)
         grounded = true;
      else
         grounded = false;

      // Character is animated properly
      myAnim.SetBool("grounded", grounded);

      float moving = Input.GetAxis("Horizontal"); // Get movingment input
      myAnim.SetInteger("AnimState", 1); // Animate movingment

      myRig.velocity = new Vector3(moving * runSpeed, myRig.velocity.y, 0); // moving Character

      float walking = Input.GetAxisRaw("Fire3"); // Get walk Input
      myAnim.SetInteger("AnimState", 2); // Animate walk

      if (walking > 0)
      {
         myRig.velocity = new Vector3(moving * walkSpeed, myRig.velocity.y, 0);
      }
      else if (walking == 0)
      {
         myRig.velocity = new Vector3(moving * runSpeed, myRig.velocity.y, 0);
      }
      else
      {
         myAnim.SetInteger("AnimState", 0);
      }

      if (moving > 0 && !facingRight)
         Flip();
      else if (moving < 0 && facingRight)
         Flip();
   }

   void Flip()
   {
      facingRight = !facingRight;
      Vector3 zedScale = transform.localScale;
      zedScale.z *= -1;
      transform.localScale = zedScale;
   }
}
