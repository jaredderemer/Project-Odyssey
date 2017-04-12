/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

   public  int   damage; // Amount of damage enemy can do
   public  float damageRate; // How often damage can be applied to character
   public  float pushBackForce; // Force applied to character when entering damage zone

   private float nextDamage; // Actual time when next damage can occur

   private bool  playerInRange = false; // Is player still within damage collider?

	[HideInInspector]public GameObject    thePlayer; // The player itself
	[HideInInspector]public PlayerHealth  thePlayerHealth; // Reference PlayerHealth Script
	[HideInInspector]public PlayerControllerTest controller;

	private float pushbackTime = 0.0f;
	private float floatTime = 0.1f;
	private float pushbackX;

	// Use this for initialization
	void Start ()
   {
      nextDamage      = Time.time; // Damaged immediately by object
      thePlayer       = GameObject.FindGameObjectWithTag("Player"); // Player is the player
      thePlayerHealth = thePlayer.GetComponent<PlayerHealth>(); // Get the player's health
		controller = thePlayer.GetComponent<PlayerControllerTest>();
	}
	
	// Update is called once per frame
	void Update ()
   {
		if (playerInRange)
		{
			Attack ();

			pushbackTime = Time.fixedTime + 0.5f;
		}

		if (Time.fixedTime < pushbackTime)
		{
			controller.pushed = true;
			//PushBack (thePlayer);
		}
		else
		{
			controller.pushed = false;
			pushbackTime = 0.0f;
			floatTime = 0.1f;
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
			PushBack (thePlayer);
         thePlayerHealth.AddDamage(damage);
         nextDamage = Time.time + damageRate;
      }
   }

   // Push the character away from the damaging object
	void PushBack(GameObject pushedObject)
   {
      // Pushes the character straight up away from the object
		Vector3 pushDirection = new Vector3(0.0f, pushedObject.transform.position.y - transform.position.y, 1.0f).normalized;

      // Set the direction of the push back
      pushDirection *= pushBackForce;

      // Access the Rigidbody
      Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();

      // Zero out the player's movement
      pushedRB.velocity = Vector3.zero;

      pushedRB.AddForce(pushDirection, ForceMode.Impulse);
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

		hitPosition.y += 0.5f;

		Vector3 upDirection = new Vector3(pushedObject.transform.position.x, hitPosition.y, pushedObject.transform.position.z);
		Vector3 backDirection = new Vector3 (x, hitPosition.y, pushedObject.transform.position.z);

		pushedObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		pushedObject.transform.position = Vector3.Lerp(upDirection, hitPosition, 0.0f);
		pushedObject.transform.position = Vector3.MoveTowards(backDirection, upDirection, 0.0f);

		pushedObject.GetComponent<Rigidbody> ().velocity = backDirection;
		Debug.Log ("backDirection: " + backDirection);
		Debug.Log ("backVelocity: " + pushedObject.GetComponent<Rigidbody> ().velocity);
   }
}
*/