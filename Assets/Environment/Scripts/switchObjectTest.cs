using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class switchObjectTest : MonoBehaviour {

   public GameObject list;

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey(KeyCode.E)) {
         list.GetComponent<CharacterSelection> ().selectCharacter ();

      }
      if (col.tag == "Player" && Input.GetKey (KeyCode.C)) {
         list.GetComponent<CharacterSelection> ().Confirm ();
      }
   }
}
