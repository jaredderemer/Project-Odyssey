/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/22/17  22:20      Enter an appropriate room               *
* Juju Moong      03/23/17  01:41      Exit to the original position           *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArea : MonoBehaviour {
   // index for each area
   private const int house  = 1;
   private const int office = 2;
   private const int pool   = 3;
   private const int main   = 4;

   public int area;             // index for a particular area
   [HideInInspector]
   public Vector3 orgPlayerPos; // player position in front of building
   [HideInInspector]
   public Vector3 orgCamPos;    // camera position in front of building

   [SerializeField]
   private int itemIDNeeded;    // Item ID necessary to unlock an object
   private Camera cam;
   private float max;
   private float min;
   private Vector3 playerPos;
   private Vector3 camPos;

	// Use this for initialization
	void Start () 
   {
      cam = Camera.main;
      setBorder ();
	}
	
   void OnTriggerEnter (Collider col)
   {
      switch (area)
      {
         case house:
         case office:
         case pool:
            orgPlayerPos = col.transform.position;
            orgCamPos = cam.transform.position;
            break;
      }
      setPosition ();
   }

   void OnTriggerStay (Collider col)
   {  
      if (col.tag == "Player" && Input.GetKey (KeyCode.E)) 
      { 
         if (gameObject.tag == "Locked") 
         {
            unlockPool (col);
         } 
         else 
         {
            StartCoroutine(movePosition (col));
         }
      }
   }

   /***************************************************************************
   * movePosition                                                             *
   * Move the positions of player and camera to an approriate area            *
   ***************************************************************************/
   IEnumerator movePosition (Collider player)
   {
      yield return new WaitForSeconds (1.0f);
      player.transform.position = playerPos;
      cam.transform.position = camPos;
      cam.GetComponent<CameraFollow2> ().minPosX = min;
      cam.GetComponent<CameraFollow2> ().maxPosX = max;
   }

   /***************************************************************************
   * unlockPool                                                               *
   * Unlock Poolhouse door if player has the key                              *
   ***************************************************************************/
   void unlockPool (Collider player)
   {
      if (player.GetComponent<Inventory2> ().removeItem (itemIDNeeded) == 1) 
      {
         gameObject.tag = "Untagged";
         StartCoroutine(movePosition (player));
      } 
      else 
      {
         Debug.Log ("You need key to unlock.");
      }
   }

   /***************************************************************************
   * setPosition                                                              *
   * Set the positions of player and camera to an approriate area             *
   ***************************************************************************/
   void setPosition ()
   {
      switch (area) 
      {
         case house:
            playerPos = new Vector3 (-116.65f, -3.2f, 15.6f);
            camPos    = new Vector3 (-116.1f, 4.5f, 0f);
            break;
         case office:
            playerPos = new Vector3 (-71.85f, -3.9f, 15.6f);
            camPos    = new Vector3 (-66.5f, 4.5f, 0f);
            break;
         case pool:
            playerPos = new Vector3 (0f,0f,0f);
            camPos    = new Vector3 (0f,0f,0f);
            break;
         case main:
            goToMain();
            break;
      }
   }

   /***************************************************************************
   * setBorder                                                                *
   * Set the minimum and maximum x position to limit camera movement for each *
   * area                                                                     *
   ***************************************************************************/
   void setBorder ()
   {
      switch (area) 
      {
         case house:
            min = -118.5f;
            max = -115.3f;
            break;
         case office:
            min = -72.0f;
            max = -70.3f;
            break;
         case pool:
            min = 0.0f;
            max = 0.0f;
            break;
         case main:
            min = -24.0f;
            max = 196.0f;
            break;
      }      
   }

   /***************************************************************************
   * goToMain                                                                 *
   * Move player and camera to the front of the building he enters            *
   ***************************************************************************/
   void goToMain ()
   {
      GameObject obj;
      if (gameObject.tag == "toHouseFront") 
      {
         obj = GameObject.Find ("House");
      } 
      else if (gameObject.tag == "toOfficeFront") 
      {
         obj = GameObject.Find ("Office");
      }
      else
      {
         obj = GameObject.Find ("Pool");
      }
      playerPos = obj.GetComponent<moveArea> ().orgPlayerPos;
      camPos    = obj.GetComponent<moveArea> ().orgCamPos;
   }
}
