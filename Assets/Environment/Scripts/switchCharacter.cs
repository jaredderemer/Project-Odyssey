/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/05/17  15:30      Switch character skin                   *
*                                      Set the index of scene to load          *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class switchCharacter : MonoBehaviour {

   public GameObject list;
   public int charIndex;
   public int sceneToLoad;

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey(KeyCode.E)) {
         list.GetComponent<CharacterSelection> ().selectCharacter (charIndex);
         GameObject.FindGameObjectWithTag ("Door").GetComponent<hutChoice> ().sceneToLoad = sceneToLoad;
      }
   }
}
