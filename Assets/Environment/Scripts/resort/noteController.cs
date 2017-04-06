/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      ??   *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteController : MonoBehaviour {
   
   private GameObject message;
   [SerializeField]
   private GameObject safe;
   [SerializeField]
   private string note;

   void Start ()
   {
      message = GameObject.FindGameObjectWithTag ("Message");
   }

   void OnTriggerEnter (Collider col)
   {
      if (col.tag == "Player") 
      {
         message.GetComponent<noteDisplay>().displayMessage(note);
         safe.tag = "Untagged";
         Destroy (gameObject);
      }
   }
}
