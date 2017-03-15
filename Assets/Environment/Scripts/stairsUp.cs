using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairsUp : MonoBehaviour {
   [SerializeField]
   private Vector3 newPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider col) 
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.W)) 
      {
         
      }
	}
}
