/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/27/17  10:05      Display a message when an object is     *
*                                      picked up to prompt what to do next     *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockNote : MonoBehaviour {

   private GameObject message;
   private string note;

   void Start ()
   {
      message = GameObject.FindGameObjectWithTag ("Message");
   }

   void OnTriggerEnter (Collider col)
   {
      if (col.tag == "Player") 
      {
         message.GetComponent<noteDisplay>().displayMessage(getNote());

      }
   }

   string getNote ()
   {
      string note;

      if (gameObject.name == "island_map-02(Clone)") 
      {
         note = "You found the other half of the map.";
      }
      else if (gameObject.name == "gate_key(Clone)") 
      {
         note = "You found the gate key.";
      }
      else if (gameObject.name == "bedroom_key") 
      {
         note = "You found the Fabrice's bedroom key.";
      }
      else if (gameObject.name == "secretary_key(Clone)") 
      {
         note = "You found the secretary's key.";
      } 
      else if (gameObject.name == "pool_key(Clone)") 
      {
         note = "You found the pool house key. Fabrice lost his bedroom key in the pool.";
      }
      else 
      {
         note = "";
      }

      return note;
   }
}
