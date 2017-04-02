using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControllerTest : MonoBehaviour
{
	public float moveSpeed;
	public bool facingRight;

	private bool playerInView;
	private GameObject player;
	private Animator myAnim;
	private Rigidbody myRB;

	// Use this for initialization
	void Start ()
	{
		playerInView = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		myRB = gameObject.GetComponent<Rigidbody> ();
		myAnim = gameObject.GetComponent<Animator> ();

		if (Random.Range (0, 10) > 5)
		{
			flip ();
		}
	}

	void onTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// The monkey will continue to follow the player until it either dies or falls off the map
			playerInView = true;
			Debug.Log ("Player found");
		}
	}

   void FixedUpdate()
   {
		if (playerInView)
		{
			move ();
		}
		else
		{
			myRB.velocity = Vector3.zero;
			// set animation to idle
		}

      /*bool attacking = Input.GetKey("F");
      if (attacking)
      {
         
      }*/
   }

   void move()
	{
		if ((player.transform.position.x < gameObject.transform.position.x && facingRight) || (player.transform.position.x > gameObject.transform.position.x && !facingRight))
		{
			flip ();
		}
		else if (player.transform.position.x == gameObject.transform.position.x) // Only happens if the player is above or below the monkey
		{
			// The monkey will be looking in the same direction as the player
			facingRight = player.GetComponent<PlayerControllerTest> ().facingRight;

			// set animation to idle
		}

		if (facingRight)
		{
			myRB.velocity = new Vector3 (moveSpeed, myRB.velocity.y, 0.0f);
		}
		else
		{
			myRB.velocity = new Vector3 (moveSpeed * -1, myRB.velocity.y, 0.0f);
		}
	}

	void flip()
	{
		gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, facingRight ? -100.0f : 100.0f, 0.0f));

		facingRight = !facingRight;
	}
}