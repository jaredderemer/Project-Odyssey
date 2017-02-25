/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Open the chest when action key is hit   *
*                                      Instantiate an object above the chest   *
*                                      Make appear hidden objects              *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour {

   public GameObject collectible;

   private Animator chestAnim;
   private AudioSource chestOpenAS;
   private bool isUsed;
   private Renderer[] hiddenList;

	// Use this for initialization
	void Start () 
   {
      chestAnim   = GetComponent<Animator> ();
      chestOpenAS = GetComponent<AudioSource> ();
      isUsed      = false;

      // Get every child's renderer and add it to the array
      hiddenList = GameObject.Find ("hidden").GetComponentsInChildren<Renderer>();
	}
	
   IEnumerator OnTriggerStay(Collider target)
   {
      // When the player hits action key for the first time, open the chest
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
         chestAnim.SetTrigger ("activateChest");
         chestOpenAS.Play ();
         yield return new WaitForSeconds (1.0f);
         Instantiate (collectible, 
                      new Vector3 (transform.position.x, 
                                   transform.position.y + 1.2f, 
                                   transform.position.z + 0.1f), 
                      transform.rotation);
         isUsed = true;

         // Loop for each item in the array, and make it appear after a certain 
         // seconds
         foreach (Renderer r in hiddenList) 
         {
            yield return new WaitForSeconds (5.0f);
            r.enabled = true;
         }
      }
   }
}
