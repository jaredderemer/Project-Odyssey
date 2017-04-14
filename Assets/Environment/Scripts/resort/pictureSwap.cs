/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/05/17  21:40      Swap picture when press a certain key   *
*                                      Easter egg #1                           *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictureSwap : MonoBehaviour {

   private bool isUsed;
   [SerializeField]
   private GameObject fabrice;

	// Use this for initialization
	void Start () 
   {
      isUsed = false;
	}
	
   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey(KeyCode.F) && !isUsed) 
      {
         // Replace a picture with Fabrice picture
         Instantiate (fabrice, 
                      new Vector3 (transform.position.x, 
                                   transform.position.y, 
                                   transform.position.z), 
                      transform.rotation);
         Destroy (gameObject);

         // Increment easter egg counter
         globalController.Instance.easterEggCounter += 1;

         isUsed = true;
      }
   }
}
