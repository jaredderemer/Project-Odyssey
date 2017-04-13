using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnd : MonoBehaviour {

   private bool isUsed;

	// Use this for initialization
	void Start () 
   {
      isUsed = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && !isUsed) 
      {
         Destroy (gameObject);

         // load ending scene

         isUsed = true;
      }
   }
}
