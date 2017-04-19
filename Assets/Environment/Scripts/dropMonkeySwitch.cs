using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropMonkeySwitch : MonoBehaviour {

	public GameObject monkeyTrap; // Game object for hidden rocks
   public float waitTime;        // Time to wait before resetting switch
   public float dropTime;        // Time to drop monkey
	private Rigidbody monkeyRB;   // Monkey's Rigidbody
   private bool triggered = false;
   private bool monkeyDropped = false;

   private AudioSource dingAS;
   private bool musicOn;

   void Start ()
   {
      monkeyRB = GameObject.Find("Monkey").GetComponent<Rigidbody>();
      dingAS  = GetComponent<AudioSource> ();
      musicOn = false;
   }
   
   void Update ()
   {
      if(triggered)
      {
         monkeyRB.AddForce(Physics.gravity * 50.0f);
      }
   }

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Weapon") 
      {
         StartCoroutine (moveToggle ());
         
         if(!monkeyDropped)
         {
            Debug.Log("Dropping");
            monkeyDropped = true;
            StartCoroutine (dropMonkeys());
         }

         // Play sound effect
         if (!musicOn) 
         {
            dingAS.Play ();
            musicOn = true;
         }
      }
   }
    
   /****************************************************************************
   * moveToggle                                                                *
   * Rotate the toggle when triggered and after a certain time, rotate it back *
   * to its original position
   ****************************************************************************/
   IEnumerator moveToggle ()
   {
      gameObject.transform.eulerAngles = new Vector3 (0f, 0f, -20f);
      yield return new WaitForSeconds (waitTime);
      gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
      musicOn = false;
   }
   
   IEnumerator dropMonkeys()
   {
      monkeyTrap.SetActive (false);
      triggered = true;
      yield return new WaitForSeconds (dropTime);
      triggered = false;
      monkeyTrap.SetActive (true);
   }
}
