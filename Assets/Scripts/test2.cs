using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {
   public GameObject cart;

   void OnTriggerStay(Collider collider)
   {
      if (Input.GetKey (KeyCode.E)) 
      {
         if (collider.gameObject.tag == "Player") 
         {
            //cart.SetActive(true);
            cart.GetComponent<MoveObject> ().enabled = true;
         }
      }
   }

}
