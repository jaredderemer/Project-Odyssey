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
            other.GetComponent<playerHealth> ().addDamage (damageAmount * 3.0f);
            other.GetComponent<playerHealth> ().addDamage (damageAmount * Time.deltaTime);
            other.GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, 300.0f, 0f));
         }
         if (other.gameObject.CompareTag ("Enemy")) 
         {
            other.GetComponent<EnemyHealth> ().AddDamage (damageAmount * 6.0f);
            other.GetComponent<EnemyHealth> ().AddDamage (damageAmount * Time.deltaTime * 2.0f);
            other.GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, 300.0f, 0f));
         }
      }
   }
}