using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

   private float min;
   private float max;

   private GameObject target;

   private Vector3 offset;

   public float length;
   public float speed;

   // Use this for initialization
   void Start () {
      min    = transform.position.x;
      max    = transform.position.x + length;
      target = null;
   }

   void OnTriggerStay(Collider collider)
   {
      target = collider.gameObject;
      offset = target.transform.position - transform.position;
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
         target.transform.position = transform.position + offset;
      }
   }
}
