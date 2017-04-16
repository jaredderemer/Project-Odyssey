using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropMonkeySwitch : MonoBehaviour {

	public GameObject monkeyTrap; // Game object for hidden rocks
   public float waitTime;        // Time to wait before reactivating the monkey trap

   private AudioSource dingAS;
   private bool musicOn;

   void Start ()
   {
      dingAS  = GetComponent<AudioSource> ();
      musicOn = false;
   }

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Weapon") 
      {
         StartCoroutine (moveToggle ());
         StartCoroutine (dropMonkeys());

         // Play sound effect
         if (!musicOn) 
         {
            dingAS.Play ();
            musicOn = true;
         }
      }
   }
    
   /****************************************************************************
   * moveToggle                                                                *
   * Rotate the toggle when triggered and after a certain time, rotate it back *
   * to its original position
   ****************************************************************************/
   IEnumerator moveToggle ()
   {
      gameObject.transform.eulerAngles = new Vector3 (0f, 0f, -20f);
      yield return new WaitForSeconds (waitTime);
      gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
      musicOn = false;
   }
   
   IEnumerator dropMonkeys()
   {
      monkeyTrap.SetActive (false);
      yield return new WaitForSeconds (waitTime);
      monkeyTrap.SetActive (true);
   }
}
