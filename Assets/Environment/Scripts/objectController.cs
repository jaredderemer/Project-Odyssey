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
   private int itemIDNeeded; // Item ID necessary to unlock an object
   [SerializeField]
   private float xOffset;
   [SerializeField]
   private float yOffset;
   [SerializeField]
   private float zOffset;
   //[SerializeField]
   //private string note;
   //private GameObject message;
   //private GameObject messageTemp;
   private Animator objAnim;
   private AudioSource objOpenAS;
   private bool isUsed;
   private bool displayed;

   // Use this for initialization
   void Start () 
   {
      objAnim     = GetComponent<Animator> ();
      objOpenAS   = GetComponent<AudioSource> ();
      isUsed      = false;
      displayed   = false;
      //message     = GameObject.FindGameObjectWithTag ("Message");
      //messageTemp = GameObject.FindGameObjectWithTag ("MessageTemp");
   }

   void OnTriggerStay(Collider target)
   {
      // When the player hits action key for the first time, open the chest
      //************************************************************************
      // Need to check if the player has a key if not show that he needs key to 
      // open chest
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
         if (gameObject.tag == "Locked") 
         {
            unlockObject (target);

         }
         else if (gameObject.tag == "Chest") 
         {
            unlockObject (target);
            StartCoroutine(gameObject.GetComponent<rockVisible> ().makeVisible ());
         }
         else
         {
            openObject ();
         }
      }
   }

   void OnTriggerExit (Collider col)
   {
      //messageTemp.GetComponent<noteDisplay> ().displayMessage ("");
      displayed = false;
   }

   void unlockObject (Collider target)
   {
      if (target.GetComponent<Inventory2> ().removeItem (itemIDNeeded) == 1) 
      {
         gameObject.tag = "Untagged";
         openObject ();
      }
      else 
      {
         if (!displayed) 
         {           
            //messageTemp.GetComponent<noteDisplay>().displayMessage(note);
            displayed = true;
         }
      }
   }

   void openObject ()
   {
      objAnim.SetTrigger ("activateObject");
      objOpenAS.Play ();
      isUsed = true;
      StartCoroutine(instantiateObj ());
      //message.GetComponent<noteDisplay>().displayMessage("");
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