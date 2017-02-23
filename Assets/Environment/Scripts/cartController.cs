using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartController : MonoBehaviour {
   public float resetTime;

   Animator cartAnim;

   float downTime;
   bool cartIsRight = false;

	// Use this for initialization
	void Start () {
      cartAnim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
      if (downTime <= Time.time && cartIsRight) 
      {
         cartAnim.SetTrigger ("activateCart");
         cartIsRight = false;
      }
	}

   void OnTriggerEnter (Collider target)
   {
      if (target.tag == "Player") 
      {
         cartAnim.SetTrigger ("activateCart");
         downTime = Time.time + resetTime;
         cartIsRight = true;
      }
   }
}
