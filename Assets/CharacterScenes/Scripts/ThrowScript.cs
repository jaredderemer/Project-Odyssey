using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script would actually go on the stick. Nick says his stick does damage. Verify the integrity of that script with this one.
public class ThrowScript : MonoBehaviour
{
   public int damage;
   public float knockback;
   public float knockbackRadius;
   public float throwRate; // Can change speed based off which weapon is used; useful for stick vs branch

   private float nextThrow;
   private int shootableMask;

   Animator myAnim;

   //PlayerControllerTest myPC;

   // Use this for initialization
   void Start()
   {
      shootableMask = LayerMask.GetMask("Shootable");   // Anything shootable can be hitable
      myAnim = transform.root.GetComponent<Animator>(); // Animator on the character itself
      //myPC = transform.root.GetComponent<PlayerControllerTest>(); // Links to PlayerControllerTest. Might just be for the Running, which we don't care about...
      nextThrow = 0f;
   }

   void FixedUpdate()
   {
      float charThrow = Input.GetAxis("Fire2"); // Fire2 is the Left Alt key and Right Mouse

      if (charThrow > 0f && nextThrow < Time.time)
      {
         myAnim.SetTrigger("CharRange");
         nextThrow = Time.time + throwRate;

         // Do Damage
         Collider[] attacked = Physics.OverlapSphere(transform.position, knockbackRadius, shootableMask);
      }
   }
}
