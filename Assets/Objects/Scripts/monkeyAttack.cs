using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyAttack : MonoBehaviour
{
   public float damage; // Amount of damage enemy can do
   public float damageRate; // How often damage can be applied to character
   public float pushBackForce; // Force applied to character when entering damage zone

   float nextDamage; // Actual time when next damage can occur

   bool playerInRange = false; // Is player still within damage collider?

   GameObject thePlayer; // The player itself
   playerHealth thePlayerHealth; // Reference playerHealth Script
   Animator myAnim;
   private float monkeySpeed;

	// Use this for initialization
	void Start ()
   {
      nextDamage = Time.time; // Damaged immediately by object
      
      thePlayer = GameObject.FindGameObjectWithTag("Player"); // Player is the player
	   myAnim = transform.parent.gameObject.GetComponent<Animator> ();
      monkeySpeed = transform.parent.gameObject.GetComponent<MonkeyControllerTest> ().moveSpeed;
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
         transform.parent.gameObject.GetComponent<MonkeyControllerTest> ().moveSpeed = monkeySpeed * 0.25f;
      }
   }

   // Player leaves damaging area
   void OnTriggerExit(Collider other)
   {
      if(other.tag == "Player")
      {
         playerInRange = false;
         transform.parent.gameObject.GetComponent<MonkeyControllerTest> ().moveSpeed = monkeySpeed;
      }
   }

   // Damage the character
   void Attack()
   {
      thePlayerHealth = thePlayer.GetComponent<playerHealth>(); // Get the player's health
      
      if (nextDamage <= Time.time)
      {
         Debug.Log(nextDamage);
         myAnim.SetTrigger("Slam");
         thePlayerHealth.addDamage(damage);
         nextDamage = Time.time + damageRate;

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