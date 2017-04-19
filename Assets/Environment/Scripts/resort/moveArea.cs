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
      if (col.tag == "Player")
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
   }

   void OnTriggerStay (Collider col)
   {  
      if (col.tag == "Player" && Input.GetKey (KeyCode.W)) 
      { 
         if (gameObject.tag == "Locked") 
         {
            if (col.GetComponent<Inventory2> ().removeItem (itemIDNeeded) == 1) 
            {
               unlockPool (col);
            }
         } 
         else 
         {
            StartCoroutine(movePosition (col));
         }
      }
   }

   /****************************************************************************
   * movePosition                                                              *
   * Move the positions of player and camera to an approriate area             *
   ****************************************************************************/
   IEnumerator movePosition (Collider player)
   {
      yield return new WaitForSeconds (1.0f);
      player.transform.position = playerPos;
      cam.transform.position    = camPos;

      if (area == 3) 
      {
         cam.transform.eulerAngles = new Vector3 (30.0f, 0.0f, 0.0f);
      } 
      else 
      {
         cam.transform.eulerAngles = new Vector3 (16.894f, 0.0f, 0.0f);
      }

      cam.GetComponent<CameraFollow2> ().minPosX = min;
      cam.GetComponent<CameraFollow2> ().maxPosX = max;
   }

   /****************************************************************************
   * unlockPool                                                                *
   * Unlock Poolhouse door if player has the key                               *
   ****************************************************************************/
   void unlockPool (Collider player)
   {
      gameObject.tag = "Untagged";
      StartCoroutine(movePosition (player));
      gameObject.GetComponentInChildren<promptInteract> ().itemIDNeeded = 0;
   }

   /****************************************************************************
   * setPosition                                                               *
   * Set the positions of player and camera to an approriate area              *
   ****************************************************************************/
   void setPosition ()
   {
      switch (area) 
      {
         case house:
            playerPos = new Vector3 (-121.1972f, -2.208784f, 15.6f);
            camPos    = new Vector3 (-114.95f, 4.5f, 0f);
            break;
         case office:
            playerPos = new Vector3 (-74.54841f, -2.832353f, 15.6f);
            camPos    = new Vector3 (-67.85f, 4.5f, 0f);
            break;
      case pool:
            playerPos = new Vector3 (-178.0f, -2.896141f, 15.6f);
            camPos    = new Vector3 (-187f, 7.75f, 0f);
            break;
         case main:
            goToMain();
            break;
      }
   }

   /****************************************************************************
   * setBorder                                                                 *
   * Set the minimum and maximum x position to limit camera movement for each  *
   * area                                                                      *
   ****************************************************************************/
   void setBorder ()
   {
      switch (area) 
      {
         case house:
            min = -121.5f;
            max = -121.5f;
            break;
         case office:
            min = -75.0f;
            max = -75.0f;
            break;
         case pool:
            min = -202.8f;
            max = -190.8f;
            break;
         case main:
            min = -24.0f;
            max = 196.0f;
            break;
      }      
   }

   /****************************************************************************
   * goToMain                                                                  *
   * Move player and camera to the front of the building he enters             *
   ****************************************************************************/
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
