using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerFall : MonoBehaviour
{
   GameObject mainCamera;

   Vector3 cameraStartPosition;
	Vector3 spawnPoint;

	// Use this for initialization
	void Start ()
	{
		spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;  // Player is the player
      mainCamera = GameObject.FindGameObjectWithTag("MainCamera");  // Main Camera object
      
      cameraStartPosition = mainCamera.transform.position;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.transform.position = cameraStartPosition;
            other.GetComponent<Rigidbody>().position = spawnPoint;
        }
	}
	
}
