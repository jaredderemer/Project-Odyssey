﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerFall : MonoBehaviour
{
   GameObject mainCamera;
   GameObject mineCart;
   cartController mineCartController;
   
   Vector3 cartStartPosition;

	// Use this for initialization
	void Start ()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");  // Main Camera object
	  
		if (globalController.Instance.currentSceneIndex == 3) // if in the cave scene
		{
         mineCart = GameObject.FindGameObjectWithTag("MineCart"); // Mine Cart object
			mineCartController = mineCart.GetComponent<cartController>();
         cartStartPosition   = mineCart.transform.position;
      }
      
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 5.0f, mainCamera.transform.position.z); // Keeps the camera from seeing below the map
            other.GetComponent<playerHealth> ().loseLife ();
			Debug.Log ("player fell out of the world");
            
			if (globalController.Instance.currentSceneIndex == 3) // if in the cave scene
			{
				// Reset mine cart position
				mineCart.transform.position = cartStartPosition;
				mineCartController.isRight = false;
			}
        }
	}
}
