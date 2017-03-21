using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerTest : MonoBehaviour
{
   // Movement
   public float runSpeed;
   public float walkSpeed;

   Rigidbody myRig;
   Animator myAnim;

   bool facingRight;

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

      if(move > 0 && !facingRight)
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
      Vector3 theScale             =  transform.localScale;
              theScale.z          *= -1;
              transform.localScale =  theScale;
   }
}
