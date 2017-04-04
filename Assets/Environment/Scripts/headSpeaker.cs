using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headSpeaker : MonoBehaviour {

	// Use this for initialization
	void Start () 
   {
		
	}
	
	// Update is called once per frame
	void Update () 
   {
		
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.E)) 
      {
         Debug.Log ("You found an Easter Egg");
      }
   }
}
