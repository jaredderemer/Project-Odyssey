/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/21/17  16:55      Replace a full map and drop secretary's *
*                                      key when action key is hit              *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapReplace : MonoBehaviour {
   
   [SerializeField]
   private int itemIDNeeded; // Item ID necessary to unlock an object
   public GameObject map;
   public GameObject collectible;

   private bool isReplaced;
   private bool displayed;

   [SerializeField]
   private float xOffset;
   [SerializeField]
   private float yOffset;
   [SerializeField]
   private float zOffset;

	// Use this for initialization
	void Start () 
   {
      isReplaced = false;	
      displayed  = false;
	}
	
   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.E) && !isReplaced) 
      {
         // add code to check if the player has the other piece of map
         if (col.GetComponent<Inventory2> ().removeItem (itemIDNeeded) == 1) 
         {
            isReplaced = true;
            StartCoroutine (instantiateObj ());
         }
         else 
         {
            if (!displayed) 
            {
               Debug.Log ("You need a key to open");
               displayed = true;
            }
         }
      }
   }

   IEnumerator instantiateObj ()
   {
      Instantiate (map, new Vector3 (transform.position.x + 1.4f, 
                                     transform.position.y + 0.03f, 
                                     transform.position.z), 
                                     transform.rotation);
      yield return new WaitForSeconds (1.0f);
      Instantiate (collectible, new Vector3 (transform.position.x + xOffset, 
                                             transform.position.y + yOffset, 
                                             transform.position.z + zOffset), 
                                             transform.rotation);
   }
}
