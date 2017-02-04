using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

   private float min;
   private float max;
   public float length;
   public float speed;
   private GameObject target;
   private Vector3 offset;

   // Use this for initialization
   void Start () {
      min = transform.position.x;
      max = transform.position.x + length;
      target = null;
   }

   void OnTriggerStay(Collider thing)
   {
      target = thing.gameObject;
      offset = target.transform.position - transform.position;
   }
   void OnTriggerExit(Collider thing)
   {
      target = null;
   }
   // Update is called once per frame
   void Update () {
      transform.position =new Vector3(Mathf.PingPong(Time.time*speed,max-min)+min, 
                                      transform.position.y, 
                                      transform.position.z);

      if (target != null) 
      {
         target.transform.position = transform.position + offset;
      }
   }
}
