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
      Debug.Log ("pushback");
      // Pushes the character straight up away from the object
      Vector3 pushDirection = new Vector3(thePlayer.GetComponent<PlayerControllerTest>().facingRight? -100.0f:100.0f, (pushedObject.position.y - transform.position.y), 0).normalized;

      // Set the direction of the push back
      pushDirection *= pushBackForce;

      // Access the Rigidbody
      Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();

      // Zero out the player's movement
      pushedRB.velocity = Vector3.zero;

      pushedRB.AddForce(pushDirection, ForceMode.Impulse);
   }
}
