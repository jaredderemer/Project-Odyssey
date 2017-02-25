/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32                                              *
*                                                                              *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour {

   public GameObject collectible;
   Animator chestAnim;
   bool isUsed;
	// Use this for initialization
	void Start () 
   {
      chestAnim = GetComponent<Animator> ();
      isUsed = false;
	}
	
   IEnumerator OnTriggerStay(Collider target)
   {
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
         chestAnim.SetTrigger ("activateChest");
         yield return new WaitForSeconds (1.0f);
         Instantiate (collectible, 
                      new Vector3 (transform.position.x, 
                                   transform.position.y + 0.7f, 
                                   transform.position.z + 0.132f), 
                      transform.rotation);
         isUsed = true;
      }
   }
}
