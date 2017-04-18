/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/30/17  15:40      Move an object back and forth           *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainMove : MonoBehaviour {

   private float min; // Minimun x position of the moving object
   private float max; // Maximum x position of the moving object

   private Transform target; // Player's transform

   private Vector3 offset;

   public float length; // Length to move the object
   public float speed;

   // Use this for initialization
   void Start () 
   {
      min = transform.position.x;
      max = transform.position.x + length;
      target = null;
   }

   void OnTriggerStay(Collider collider)
   {
      if(collider.tag == "Player")
      {
         target = collider.transform;
         offset = target.position - transform.position;
      }
   }

   void OnTriggerExit(Collider collider)
   {
      target = null;
   }

   // Update is called once per frame
   void Update () 
   {
      transform.position = new Vector3(Mathf.PingPong(Time.time*speed,max-min)+min, 
         transform.position.y, 
         transform.position.z);

      if (target != null) 
      {
         target.position = transform.position + offset;
      }
   }
}
