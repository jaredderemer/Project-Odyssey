using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroy : MonoBehaviour {

   public float lifetime; // Time before object is destroyed
   public GameObject disappearEffect;
   
   
   
   // Use this for initialization
   void Start ()
   {
      Destroy(this.gameObject, lifetime);
      
   }
   
   void OnDestroy ()
   {
      Instantiate(disappearEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
   }
}
