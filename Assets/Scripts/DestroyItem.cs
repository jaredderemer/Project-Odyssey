using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {


   void OnTriggerStay(Collider item)
   {
      if (Input.GetKey (KeyCode.E)) 
      {
         if (item.gameObject.tag == "Item") 
         {
            Destroy (item.gameObject);
         }
      }
   }
}
