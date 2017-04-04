using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script would actually go on the stick. Nick says his stick does damage. Verify the integrity of that script with this one.
public class MeleeScript : MonoBehaviour
{
   public int damage;
   public float knockback;
   public float knockbackRadius;
   public float meleeRate; // Can change speed based off which weapon is used; useful for stick vs branch

   private float nextMelee;
   private int shootableMask;

   Animator myAnim;

   //PlayerControllerTest myPC;

   // Use this for initialization
   void Start()
   {
      shootableMask = LayerMask.GetMask("Shootable");   // Anything shootable can be hitable
      myAnim = transform.root.GetComponent<Animator>(); // Animator on the character itself
      //myPC = transform.root.GetComponent<PlayerControllerTest>(); // Links to PlayerControllerTest. Might just be for the Running, which we don't care about...
      nextMelee = 0f;
   }

   void FixedUpdate()
   {
      float melee = Input.GetAxis("Fire2"); // Fire2 is the Left Alt key and Right Mouse

      if (melee > 0 && nextMelee < Time.time)
      {
         myAnim.SetTrigger("CharMelee");
         nextMelee = Time.time + meleeRate;

         // Do Damage
         Collider[] attacked = Physics.OverlapSphere(transform.position, knockbackRadius, shootableMask);
      }
   }
}
