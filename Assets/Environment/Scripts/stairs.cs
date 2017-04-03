/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/14/17  12:06      Go up and down the stairs               *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairs : MonoBehaviour {
   
   private bool isDown;
   [SerializeField]
   private Vector3 newPos;
   [SerializeField]
   private Vector3 originalPos;

	// Use this for initialization
	void Start () {
      isDown = true;
	}
	
   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
      {
         if (isDown) 
         {
            col.transform.position = newPos;
         } 
         else 
         {
            col.transform.position = originalPos;
         }
         isDown = !isDown;
      }
 
      if (col.transform.position.y < (newPos.y - 1.0f)) 
      {
         isDown = true;
      }
   }
}
