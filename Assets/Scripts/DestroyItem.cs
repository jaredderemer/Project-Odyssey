using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {

   void OnTriggerStay(Collider collider)
   {
      if (Input.GetKey (KeyCode.E)) 
      {
         if (collider.gameObject.tag == "Weapon") 
         {
            Destroy (gameObject);
         }
      }
   }
}
