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
                         transform.position + (transform.forward * 0.1f), 
                         transform.rotation);
         }
      }
   }
}
