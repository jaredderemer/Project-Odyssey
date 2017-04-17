using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControllerTest : MonoBehaviour
{
	public float moveSpeed;
	public Collider detectionArea;
	[HideInInspector]public bool facingRight;
	[HideInInspector]public bool detected;

	private GameObject player;
	private Animator myAnim;
	private Rigidbody myRB;

	// Use this for initialization
	void Start ()
	{
		//detected = false;
		player   = GameObject.FindGameObjectWithTag ("Player");
		myRB     = gameObject.GetComponent<Rigidbody>();
		myAnim   = gameObject.GetComponent<Animator> ();

		if (Random.Range (0, 10) > 5)
		{
			Flip ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !detected)
		{
			// The monkey will continue to follow the player until it either dies or falls off the map
			detected = true;
			Debug.Log ("Player found");
		}
	}

   // Monkey Cease-to-Follow code should we decide to use it later
   void OnTriggerExit(Collider other)
   {
      if(globalController.Instance.currentSceneIndex != 6 && gameObject.name != "Boss")
      {
         Debug.Log("in if");
         if (other.tag == "Player" && detected)
         {
            detected = false;
            Debug.Log ("Player Lost");
         }
      }
      
   }

   void FixedUpdate()
   {
		if (detected)
		{
         myAnim.SetFloat("speed", 1.0f);
			Move ();
		}
		else
		{
			myRB.velocity = Vector3.zero;
         // set animation to idle
         myAnim.SetFloat("speed", 0.0f);
		}
   }

   void Move()
	{
		if ((player.transform.position.x < gameObject.transform.position.x && facingRight) || (player.transform.position.x > gameObject.transform.position.x && !facingRight))
		{
			Flip ();
		}
		else if (player.transform.position.x == gameObject.transform.position.x) // Only happens if the player is above or below the monkey
		{
			// The monkey will be looking in the same direction as the player
			facingRight = player.GetComponent<PlayerControllerTest> ().facingRight;

         // set animation to idle
         myAnim.SetFloat("speed", 0.0f);
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

	public void Flip()
	{
		gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, facingRight ? -100.0f : 100.0f, 0.0f));
		detectionArea.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, facingRight ? -10.0f : 10.0f, 0.0f));

		facingRight = !facingRight;
	}
}
