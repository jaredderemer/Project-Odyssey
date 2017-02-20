using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
   //public int flashLength;
   Renderer rend;
	// Use this for initialization
	void Start () {
      rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
      FlashObject ();
	}

   IEnumerator FlashObject()
   {
      //yield return new WaitForSeconds (100);
      //for (int i = 1; i <= flashLength; i++) 
      //{
      rend.enabled = false;
         yield return new WaitForSeconds (10);
         rend.enabled = true;
         yield return new WaitForSeconds (10);
     // }
   }
}
