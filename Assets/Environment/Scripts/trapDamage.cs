using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDamage : MonoBehaviour {

   public float damageAmount;

   // Hurts player on contact
   void OnTriggerStay(Collider other)
   {
      if (GetComponent<Collider>() != null)
      {
         if (other.gameObject.CompareTag ("Player")) 
         {
            other.GetComponent<playerHealth> ().addDamage (damageAmount * Time.deltaTime);
         }
      }
   }
}