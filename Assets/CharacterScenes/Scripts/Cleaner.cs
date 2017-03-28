using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         playerHealth PlayerDead = other.gameObject.GetComponent<playerHealth>();
         PlayerDead.MakeDead();
      }
      else
      {
         Destroy(gameObject);
      }
   }
}
