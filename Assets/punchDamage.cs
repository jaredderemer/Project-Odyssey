using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchDamage : MonoBehaviour {

	GameObject thePlayer; // The player itself
   playerHealth thePlayerHealth; // Reference playerHealth Script
   public float damageAmount;
   public float pushBackForce; // Force applied to character when entering damage zone

	// Use this for initialization
	void Start ()
   {
      thePlayer = GameObject.FindGameObjectWithTag("Player"); // Player is the player
      thePlayerHealth = thePlayer.GetComponent<playerHealth>();
	}
	
	void OnTriggerEnter(Collider other)
   {
      if(other.tag == "Player")
      {
         thePlayerHealth.addDamage(damageAmount);
         pushBack(thePlayer.transform);
      }
   }

   // Push the character away from the damaging object
   void pushBack(Transform pushedObject)
	{
	   Rigidbody monkey = gameObject.GetComponentInParent<Rigidbody>().GetComponentInParent<Rigidbody>().GetComponentInParent<Rigidbody>().GetComponentInParent<Rigidbody>().GetComponentInParent<Rigidbody>();
      Debug.Log ("pushback");
      // Pushes the character straight up away from the object
      Vector3 pushDirection = new Vector3(monkey.transform.position.x > pushedObject.position.x ? -100.0f : 100.0f, 5.0f, 0.0f).normalized;

      // Set the direction of the push back
      pushDirection *= pushBackForce;

      // Access the Rigidbody
      Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();

      // Zero out the player's movement
      pushedRB.velocity = Vector3.zero;

      pushedRB.AddForce(pushDirection, ForceMode.VelocityChange);
   }
}
