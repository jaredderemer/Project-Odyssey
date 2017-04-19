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
            other.GetComponent<playerHealth> ().addDamage (damageAmount * 2.0f);
            if (other.gameObject.GetComponent<playerHealth> ().currentHealth > 0) 
            {  
               other.GetComponent<playerHealth> ().addDamage (damageAmount * Time.deltaTime);
            }
            other.GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, 500.0f, 0f));
         }
         if (other.gameObject.CompareTag ("Enemy")) 
         {
            if (gameObject.CompareTag ("Enemy")) 
            {
               other.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;   
            } 
            else 
            {
               other.GetComponent<EnemyHealth> ().AddDamage (damageAmount * 4.0f);
               other.GetComponent<EnemyHealth> ().AddDamage (damageAmount * Time.deltaTime * 2.0f);
               other.GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, 300.0f, 0f));
            }
         }
      }
   }
}