using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryPlayer : MonoBehaviour {

   private Transform target;
   private Vector3 offset;

   // Use this for initialization
   void Start () 
   {
      target = null;
   }

   void OnTriggerStay(Collider collider)
   {
      target = collider.transform;
      offset = target.position - transform.position;
   }

   void OnTriggerExit(Collider collider)
   {
      target = null;
   }

   // Update is called once per frame
   void Update () 
   {

      if (target != null) 
      {
         target.position = transform.position + offset;
      }
   }
}
