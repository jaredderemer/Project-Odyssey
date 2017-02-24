using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

   // Movement variables
   public float runSpeed;
   public float sprintSpeed;

   Rigidbody myRB;
   // Animator myAnim;

    public bool facingRight;

   // for jumping
   // Character is starting slightly off the ground, otherwise change to TRUE
   bool grounded = false;
   Collider[] groundCollisions;
   float groundCheckRadius = 0.2f;
   public LayerMask groundLayer;
   public Transform groundCheck;
   public float jumpHeight;

   // Use this for initialization
   void Start()
   {
      myRB = GetComponent<Rigidbody>();
      // myAnim = GetComponent<Animator>();
      facingRight = true;
   }

   // Update is called once per frame
   void Update()
   {

   }

   private void FixedUpdate()
   {
      if (grounded && Input.GetAxis("Jump") > 0)
      {
         grounded = false;
         //myAnim.SetBool("grounded", grounded);
         myRB.AddForce(new Vector3(0, jumpHeight, 0));
      }
      groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);

      if (groundCollisions.Length > 0)
         grounded = true;
      else
         grounded = false;

      //myAnim.SetBool("grounded", grounded);

      float move = Input.GetAxis("Horizontal");
      // myAnim.SetFloat("speed", Mathf.Abs(move));

      myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);

      float sprinting = Input.GetAxisRaw("Fire3");
      //myAnim.SetFloat("sprinting", sprinting);

      if (sprinting > 0 && grounded)
      {
         myRB.velocity = new Vector3(move * sprintSpeed, myRB.velocity.y, 0);
      }
      else
      {
         myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
      }

      if (move > 0 && !facingRight)
         Flip();
      else if (move < 0 && facingRight)
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
