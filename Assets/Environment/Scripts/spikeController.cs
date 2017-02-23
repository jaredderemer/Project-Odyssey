using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour {

   Animator spikeAnim;
   bool flag;

   // Use this for initialization
   void Start () {
      spikeAnim = GetComponent<Animator> ();
      flag = false;
   }

   void Update()
   {
      if (flag)
      {
         spikeAnim.SetTrigger ("activateSpike");
         flag = false;
      }
   }

   void OnTriggerStay (Collider target)
   {
      if (target.tag == "Player") 
      {
         spikeAnim.SetTrigger ("activateSpike");
         flag = true;
      }
   }

   void OnTriggerExit (Collider target)
   {
      if (target.tag == "Player") 
      {
         flag = false;
      }
   }
}
