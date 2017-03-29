using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

   public  int   damage; // Amount of damage enemy can do
   public  float damageRate; // How often damage can be applied to character
   public  float pushBackForce; // Force applied to character when entering damage zone

   private float nextDamage; // Actual time when next damage can occur

   private bool  playerInRange = false; // Is player still within damage collider?

   public GameObject    thePlayer; // The player itself
   public playerHealth  thePlayerHealth; // Reference playerHealth Script
	public playerController controller;

	// Use this for initialization
	void Start ()
   {
      nextDamage      = Time.time; // Damaged immediately by object
      thePlayer       = GameObject.FindGameObjectWithTag("Player"); // Player is the player
      thePlayerHealth = thePlayer.GetComponent<playerHealth>(); // Get the player's health
		controller = thePlayer.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update ()
   {
      if (playerInRange)
      {
         Attack();
      }
	}

   // Player enters damaging area
   void OnTriggerEnter(Collider other)
   {
      if(other.tag == "Player")
      {
         playerInRange = true;
      }
   }

   // Player leaves damaging area
   void OnTriggerExit(Collider other)
   {
      if(other.tag == "Player")
      {
         playerInRange = false;
      }
   }

   // Damage the character
   void Attack()
   {
      if (nextDamage <= Time.time)
		{
			PushBack(thePlayer);
         thePlayerHealth.AddDamage(damage);
         nextDamage = Time.time + damageRate;
      }
   }

   // Push the character away from the damaging object
	void PushBack(GameObject pushedObject)
   {
      /*// Pushes the character straight up away from the object
		Vector3 pushDirection = new Vector3(0.0f, pushedObject.transform.position.y - transform.position.y, 1.0f).normalized;

      // Set the direction of the push back
      pushDirection *= pushBackForce;

      // Access the Rigidbody
      Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();

      // Zero out the player's movement
      pushedRB.velocity = Vector3.zero;

      pushedRB.AddForce(pushDirection, ForceMode.Impulse);*/
		float x = 0;

		if (controller.facingRight)
		{
			x = pushedObject.transform.position.x - pushBackForce;
		}
		else
		{
			x = pushedObject.transform.position.x + pushBackForce;
		}

		Vector3 hitPosition = pushedObject.transform.position;

		hitPosition.y += 1.0f;

		Vector3 upDirection = new Vector3(pushedObject.transform.position.x, hitPosition.y, pushedObject.transform.position.z);
		Vector3 backDirection = new Vector3 (x, hitPosition.y, pushedObject.transform.position.z);

		controller.enabled = false;

		pushedObject.transform.position = Vector3.Lerp(upDirection, hitPosition, 0.0f);
		pushedObject.transform.position = Vector3.MoveTowards(backDirection, upDirection, 0.05f);

		while (!controller.grounded)
		{
			controller.enabled = false;
		}

		controller.enabled = true;
   }
}
