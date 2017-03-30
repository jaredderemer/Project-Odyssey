using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDetection : MonoBehaviour
{
	void onTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			GetComponent<MonkeyControllerTest>().playerInView = true;
		}
	}

	void onTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			GetComponent<MonkeyControllerTest>().playerInView = false;
		}
	}
}