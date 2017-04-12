/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/03/17  22:55      Show path and play sound when elevator  *
*                                      toggle is triggered                     *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockPath : MonoBehaviour {

   public GameObject hidden; // Game object for hidden rocks
   public float waitTime;    // Time to wait before hiding path

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
         StartCoroutine (makePath ());

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

   /****************************************************************************
   * makePath                                                                  *
   * Show the path                                                             *
   ****************************************************************************/
   IEnumerator makePath ()
   {
      hidden.SetActive (true);
      yield return new WaitForSeconds (waitTime);
      hidden.SetActive (false);
   }
}
