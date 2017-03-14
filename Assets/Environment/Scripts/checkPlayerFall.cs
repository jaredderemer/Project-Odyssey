using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerFall : MonoBehaviour
{
   GameObject mainCamera;
   GameObject mineCart;
   cartController mineCartController;

   Vector3 cameraStartPosition;
	Vector3 spawnPoint;
   Vector3 cartStartPosition;

	// Use this for initialization
	void Start ()
	{
		spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;  // Player is the player
      mainCamera = GameObject.FindGameObjectWithTag("MainCamera");  // Main Camera object
      mineCart = GameObject.FindGameObjectWithTag("MineCart"); // Mine Cart object
      mineCartController = mineCart.GetComponent<cartController>();
      
      cameraStartPosition = mainCamera.transform.position;
      cartStartPosition   = mineCart.transform.position;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.transform.position = cameraStartPosition;
            other.GetComponent<Rigidbody>().position = spawnPoint;
            
            // Reset mine cart position
            mineCart.transform.position = cartStartPosition;
            mineCartController.isRight = false;
        }
	}
	
}
