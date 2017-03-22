/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Open an object when action key is hit   *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour {

   public GameObject collectible;

   [SerializeField]
   private float xOffset;
   [SerializeField]
   private float yOffset;
   [SerializeField]
   private float zOffset;
   private Animator objAnim;
   private AudioSource objOpenAS;
   private bool isUsed;


	// Use this for initialization
	void Start () 
   {
      objAnim   = GetComponent<Animator> ();
      objOpenAS = GetComponent<AudioSource> ();
      isUsed      = false;
	}
	
   void OnTriggerStay(Collider target)
   {
      // When the player hits action key for the first time, open the chest
      //************************************************************************
      // Need to check if the player has a key if not show that he needs key to 
      // open chest
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
         //if (target.GetComponent<Inventory2> ().removeItem (itemID)) 
         {
            objAnim.SetTrigger ("activateObject");
            objOpenAS.Play ();

            isUsed = true;
            StartCoroutine(instantiateObj ());
            if (gameObject.tag == "Chest") 
            {
               GetComponent<rockVisible> ().makeVisible ();
            }
         }
      }
   }

   IEnumerator instantiateObj()
   {
      yield return new WaitForSeconds (1.0f);
      Instantiate (collectible, new Vector3 (transform.position.x + xOffset, 
                                             transform.position.y + yOffset, 
                                             transform.position.z + zOffset), 
                                             transform.rotation);
   }
}
