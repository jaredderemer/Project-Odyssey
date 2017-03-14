﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
   public float   speed             = 150f;
   public Vector3 maxVelocity       = new Vector3(60, 100, 0);
   public float   jumpSpeed;
   public bool    standing;
   public float   standingThreshold = 4f;
   public float jumpSpeedMultiplier = .3f;

   private Rigidbody myBody;
   private Animator myAnimator;
   private bool facingRight;
   private PlayerControllerTest controller;
   private Animator animator;

   // Use this for initialization
   void Start()
   {
      myBody = GetComponent<Rigidbody>();
      myAnimator = GetComponent<Animator>();
      facingRight = true;
      controller = GetComponent<PlayerControllerTest>();
      animator = GetComponent<Animator>();
   }

   // Update is called once per frame
   void Update()
   {
      var absVelX = Mathf.Abs(myBody.velocity.x);
      var absVelY = Mathf.Abs(myBody.velocity.y);

      if( absVelY <= standingThreshold)
      {
         standing = true;
      }
      else
      {
         standing = false;
      }

      var forceX = 0f;
      var forceY = 0f;

      if ((controller.moving.x != 0) && facingRight)
      {
         if (absVelX < maxVelocity.x)
         {
            var newSpeed = speed * controller.moving.x;


            forceX = standing ? newSpeed : (newSpeed * jumpSpeedMultiplier);
         }

      }
      else if (Input.GetKey("left") && !facingRight)
      {
         if (absVelX < maxVelocity.x)
         {
            forceX = standing ? -speed : (-speed * jumpSpeedMultiplier);
         }
      }
      else
      {
         Flip();
      }

      if (controller.moving.y > 0)
      {
         if (absVelY < maxVelocity.y)
         {
            forceY = jumpSpeed * controller.moving.y;
         }
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
