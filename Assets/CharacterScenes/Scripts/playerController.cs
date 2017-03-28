using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
// Public variables
   // Movement variables
   public float       runSpeed;
   public float       walkSpeed;

   // Jumping variables
   public LayerMask   groundLayer;
   public Transform   groundCheck;
   public float       jumpHeight;

// Private Variables
   // Character Control
   private Rigidbody  myRig;
   private Animator   myAnim;

   // Character Direction
   [HideInInspector]public bool       facingRight;

   // for jumping
   // Character is starting off the ground, otherwise change to TRUE
   [HideInInspector]public bool       grounded = false;
   private Collider[] groundCollisions;
   // Based off experience, this code should just work...
   private float      groundCheckRadius = 0.2f; 

// Class functions
   // Use this for initialization
   void Start()
   {
      myRig         = GetComponent<Rigidbody>();
      myAnim        = GetComponent<Animator> ();
      // Character starts facing right
      facingRight = true;
      myAnim.SetInteger("AnimState", 0);
   }

   // Using FixedUpdate() for physics' sake
   void FixedUpdate()
   {
      // Small area under character to determine if character is on the ground or not
      groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);

      if (grounded && Input.GetAxis("Jump") > 0)
      {
         myRig.AddForce(new Vector3(0, jumpHeight, 0));
         grounded = false;
         myAnim.SetBool("grounded", grounded);
         myAnim.SetInteger("AnimState", 3);
      }

      // Character on ground?
      if (groundCollisions.Length > 0)
         grounded = true;
      else
         grounded = false;

      // Character is animated properly
      myAnim.SetBool("grounded", grounded);

      // Get movement input
      float moving = Input.GetAxis("Horizontal");

      // Move Character
      myRig.velocity = new Vector3(moving * runSpeed, myRig.velocity.y, 0);

      // Get walk Input
      float walking = Input.GetAxisRaw("Fire3");

      if (moving != 0 && walking > 0)
      {
         // Move character at walk speed
         myRig.velocity = new Vector3(moving * walkSpeed, myRig.velocity.y, 0);

         // Animate walk
         myAnim.SetInteger("AnimState", 2);
      }
      else if (moving != 0 && walking == 0)
      {
         // Move character at run speed
         myRig.velocity = new Vector3(moving * runSpeed, myRig.velocity.y, 0);

         // Animate run
         myAnim.SetInteger("AnimState", 1);
      }
      else
      {
         // Animate idle
         myAnim.SetInteger("AnimState", 0);
      }

      // Character facing correct direction?
      if (moving > 0 && !facingRight)
         Flip();
      else if (moving < 0 && facingRight)
         Flip();
   }

   // Reverses the character's direction
   void Flip()
   {
              facingRight          = !facingRight;
      Vector3 zedScale             =  transform.localScale;
              zedScale.z           = -zedScale.z;
              transform.localScale =  zedScale;
   }
}
