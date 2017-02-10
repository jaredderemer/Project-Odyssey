using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbientSound : MonoBehaviour {

   AudioSource ambientAS;

	// Use this for initialization
	void Start () {
      ambientAS = GetComponent<AudioSource> ();
	}
	
   void OnTriggerEnter(Collider thing)
   {
      ambientAS.Play ();
   }

   void OnTriggerExit(Collider thing)
   {
      ambientAS.Stop ();
   }
}
