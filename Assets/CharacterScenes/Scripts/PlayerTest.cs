using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
   public float   speed       = 150f;
   public Vector3 maxVelocity = new Vector3(60, 100, 0);

   private Rigidbody myBody;
   private Animator  myAnimator;

   // Use this for initialization
   void Start()
   {
      myBody     = GetComponent<Rigidbody>();
      myAnimator = GetComponent<Animator> ();
   }

   // Update is called once per frame
   void Update()
   {
      var absVelX = Mathf.Abs(myBody.velocity.x);

      var forceX = 0f;
      var forceY = 0f;

      if (Input.GetKey("right"))
      {
         if(absVelX < maxVelocity.x)
         {
            forceX = speed;
         }
         else if (Input.GetKey("left"))
         {
            if(absVelX <maxVelocity.x)
            {
               forceX = -speed;
            }
         }

         myBody.AddForce(new Vector3(forceX, forceY, 0));
      }
   }
}
