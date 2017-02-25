/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      destroy an item                         *
* Juju Moong      02/24/17  15:32      instantiate a random object             *                                                               *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {
   List<GameObject> objList;

   public GameObject objOne;
   public GameObject objTwo;
   public GameObject objThree;

   private int index;

   void Start()
   {
      objList = new List<GameObject>();
      objList.Add (objOne);
      objList.Add (objTwo);
      objList.Add (objThree);
   }

   void OnTriggerStay(Collider collider)
   {
      if (Input.GetKey (KeyCode.E)) 
      {
         if (collider.tag == "Player") 
         {
            Destroy (gameObject);
            index = (int)Random.Range (0, 3);
            Instantiate (objList [index], 
                         new Vector3 (transform.position.x, 
                                      transform.position.y + 0.7f, 
                                      transform.position.z + 0.132f), 
                         Quaternion.identity);
         }
      }
   }
}
