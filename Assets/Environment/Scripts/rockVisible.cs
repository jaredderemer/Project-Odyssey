/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/13/17  15:17      Make appear hidden objects              *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockVisible : MonoBehaviour {
   public GameObject hidden;
   private Renderer[] hiddenList;
	// Use this for initialization
	void Start () 
   {
      // Get every child's renderer and add it to the array
      hiddenList = hidden.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	public IEnumerator makeVisible () 
   {
      // Loop for each item in the array, and make it appear after a certain 
      // seconds
      foreach (Renderer r in hiddenList) 
      {
         yield return new WaitForSeconds (3.0f);
         r.enabled = true;
      }
	}
}
