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

   public GameObject player;
   public int charIndex; // 0 == default; 1 == miner; 2 == tourist
   public int sceneToLoad;

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey(KeyCode.E)) 
      {
         PlayerPrefs.SetInt ("CharacterSelected", charIndex);
         player.GetComponent<meshSelector> ().selectMesh ();
         GameObject.FindGameObjectWithTag ("Door").GetComponent<hutChoice> ().sceneToLoad = sceneToLoad;
      }
   }
}
