using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchDamage : MonoBehaviour {

	GameObject thePlayer; // The player itself
   playerHealth thePlayerHealth; // Reference playerHealth Script
   public float damageAmount;
   public float pushBackForce; // Force applied to character when entering damage zone

	private float pushBackTime;

	// Use this for initialization
	void Start ()
   {
      thePlayer = GameObject.FindGameObjectWithTag("Player"); // Player is the player
      thePlayerHealth = thePlayer.GetComponent<playerHealth>();
		pushBackTime = Time.fixedTime;
	}

	void FixedUpdate ()
	{
		if (pushBackTime > Time.fixedTime)
		{
			thePlayer.GetComponent<PlayerControllerTest> ().pushed = true;
		}
		else
		{
			thePlayer.GetComponent<PlayerControllerTest> ().pushed = false;
		}
	}
	
	void OnTriggerEnter(Collider other)
   {
		if(other.tag == "Player" && pushBackTime <= Time.fixedTime)
      {
         thePlayerHealth.addDamage(damageAmount);
		 pushBack (thePlayer.transform);
      }
   }

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && pushBackTime <= Time.fixedTime)
		{
			pushBack (thePlayer.transform);
		}
	}

   // Push the character away from the damaging object
   void pushBack(Transform pushedObject)
	{
      Rigidbody monkey = gameObject.GetComponentInParent<Rigidbody>();
      Debug.Log (monkey);
      // Pushes the character straight up away from the object
		Vector3 pushDirection = new Vector3(monkey.transform.position.x > pushedObject.position.x ? -10.0f : 10.0f, 1.0f, 0.0f);//.normalized;

      // Access the Rigidbody
      Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();

      // Zero out the player's movement
		pushedRB.velocity = Vector3.zero;
		pushedRB.AddForce(pushDirection * pushBackForce, ForceMode.VelocityChange);

		pushBackTime = Time.fixedTime + 0.25f;
   }
}
