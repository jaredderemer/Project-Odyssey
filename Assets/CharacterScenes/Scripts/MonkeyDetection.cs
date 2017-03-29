using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDetection : MonoBehaviour
{
	private bool playerInView = false;

	void Start ()
	{

	}

	void Update ()
	{
		if (playerInView)
		{
			followPlayer ();
		}
	}

	void onTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			playerInView = true;
		}
	}

	void onTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			playerInView = false;
		}
	}

	void followPlayer()
	{

	}
}