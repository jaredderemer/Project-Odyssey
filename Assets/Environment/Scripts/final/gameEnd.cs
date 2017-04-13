using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player") 
      {
         Destroy (gameObject);
      }
   }
}
