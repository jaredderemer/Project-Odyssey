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
   public GameObject hidden;
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
      hiddenList = hidden.GetComponentsInChildren<Renderer>();
	}
	
   IEnumerator OnTriggerStay(Collider target)
   {
      // When the player hits action key for the first time, open the chest
      //************************************************************************
      // Need to check if the player has a key if not show that he needs key to 
      // open chest
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
         chestAnim.SetTrigger ("activateChest");
         chestOpenAS.Play ();
         yield return new WaitForSeconds (1.0f);
         
         // This was instantiated multiple collectibles
         /*Instantiate (collectible, 
                      new Vector3 (transform.position.x, 
                                   transform.position.y + 2.0f, 
                                   transform.position.z + 0.1f), 
                      transform.rotation);*/
         
         if(!isUsed)
         {
            Instantiate (collectible, 
                      new Vector3 (transform.position.x, 
                                   transform.position.y + 2.0f, 
                                   transform.position.z + 0.1f), 
                      transform.rotation);
                      
                      Debug.Log("running");
         }
         
         isUsed = true;
         
         

         // Loop for each item in the array, and make it appear after a certain 
         // seconds
         foreach (Renderer r in hiddenList) 
         {
            yield return new WaitForSeconds (3.0f);
            r.enabled = true;
         }
      }
   }
}
