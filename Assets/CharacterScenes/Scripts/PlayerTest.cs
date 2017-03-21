using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
/*   public float   speed               = 150f;
   public Vector3 maxVelocity         = new Vector3(60, 100, 0);
   public float   jumpSpeed;
   public bool    standing;
   public float   standingThreshold   =  4f;
   public float   jumpSpeedMultiplier = .3f;

   private Rigidbody            myBody;
   private Animator             myAnimator;
   private bool                 facingRight;
   private PlayerControllerTest controller;
*/
   public float       runSpeed;
   public float       walkSpeed;
   public LayerMask   groundLayer;
   public Transform   groundCheck;
   public float       jumpHeight;

   private Animator   myAnim;
   private bool       grounded = false;
   private Collider[] groundCollisions;
   private float      groundCheckRadius = 0.2f;
   private Rigidbody  myRig;

   // Use this for initialization
   void Start()
   {
      myBody      = GetComponent<Rigidbody>();
      myAnimator  = GetComponent<Animator>();
      facingRight = true;
      controller  = GetComponent<PlayerControllerTest>();
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      
      var absVelX = Mathf.Abs(myBody.velocity.x);
      var VelY = Mathf.Abs(myBody.velocity.y);
      /*
      if(VelY <= standingThreshold)
      {
         standing = true;
      }
      else
      {
         standing = false;
      }
      */
      var forceX = 0f;
      var forceY = 0f;

      if (controller.moving.x != 0)
      {
         if(absVelX < maxVelocity.x)
         {
            var newSpeed = speed * controller.moving.x;


            forceX = standing ? newSpeed : (newSpeed * jumpSpeedMultiplier);

            Flip();
         }
         myAnimator.SetInteger("AnimState", 1);
      }
      else
      {
         myAnimator.SetInteger("AnimState", 0);
      }
      //if ((controller.moving.x != 0) && facingRight)
      //{
      //   if (absVelX < maxVelocity.x)
      //   {
      //      var newSpeed = speed * controller.moving.x;


      //      forceX = standing ? newSpeed : (newSpeed * jumpSpeedMultiplier);
      //   }

      //}
      //else if (Input.GetKey("left") && !facingRight)
      //{
      //   if (absVelX < maxVelocity.x)
      //   {
      //      forceX = standing ? -speed : (-speed * jumpSpeedMultiplier);
      //   }
      //}
      //else
      //{
      //   Flip();
      //}

      if ((Input.GetAxis("Jump") > 0) && standing)
      {
         myAnimator.SetInteger("AnimState", 3);
         if (VelY > 0)
         {
            forceY = jumpSpeed * controller.moving.y;
            myAnimator.SetInteger("AnimState", 4);
         }
      }
      else if(VelY < 0 && !standing)
      {
         myAnimator.SetInteger("AnimState", 5);
      }
      else
      {
         myAnimator.SetInteger("AnimState", 6);
      }
      myBody.AddForce(new Vector3(forceX, forceY, 0));

   }

   void Flip()
   {
              facingRight          = !facingRight;
      Vector3 flipScale            = transform.localScale;
              flipScale.z         *= -1;
              transform.localScale = flipScale;
   }
}
