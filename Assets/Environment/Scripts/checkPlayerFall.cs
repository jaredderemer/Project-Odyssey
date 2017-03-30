using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerFall : MonoBehaviour
{
   GameObject mainCamera;
   GameObject mineCart;
   cartController mineCartController;

   Vector3 cameraStartPosition;
   Vector3 cartStartPosition;

	// Use this for initialization
	void Start ()
	{
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
            other.GetComponent<playerHealth> ().loseLife ();
            Debug.Log ("player fell out of the world");
            
            // Reset mine cart position
            mineCart.transform.position = cartStartPosition;
            mineCartController.isRight = false;
        }
	}
	
}
