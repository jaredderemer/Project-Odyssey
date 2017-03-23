/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/22/17  22:20      Enter an appropriate room               *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArea : MonoBehaviour {

   public int area;
   [HideInInspector]
   public Vector3 orgPlayerPos;
   [HideInInspector]
   public Vector3 orgCamPos;

//   [SerializeField]
//   private GameObject house;
//   [SerializeField]
//   private GameObject office;
//   [SerializeField]
//   private GameObject pool;
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
         case 1:
         case 2:
         case 3:
            orgPlayerPos = col.transform.position;
            orgCamPos    = cam.transform.position;
            Debug.Log ("x = " + orgPlayerPos.x);
            break;
      }
      setPosition ();
   }

   IEnumerator OnTriggerStay (Collider col)
   {  
      if (col.tag == "Player" && Input.GetKey (KeyCode.R)) {   
         yield return new WaitForSeconds (1.0f);
         col.transform.position = playerPos;
         cam.transform.position = camPos;
         cam.GetComponent<CameraFollow2> ().minPosX = min;
         cam.GetComponent<CameraFollow2> ().maxPosX = max;
         Debug.Log ("after x = " + playerPos.x);
      }
   }

   void setPosition ()
   {
      switch (area) 
      {
         case 1: // house
            playerPos = new Vector3 (-116.65f, -3.2f, 15.6f);
            camPos    = new Vector3 (-116.1f, 4.5f, 0f);
            break;
         case 2: // office
            playerPos = new Vector3 (-71.85f, -3.9f, 15.6f);
            camPos    = new Vector3 (-66.5f, 4.5f, 0f);
            break;
         case 3: // pool
            playerPos = new Vector3 (0f,0f,0f);
            camPos    = new Vector3 (0f,0f,0f);
            break;
         case 4: // main
            goToMain();
            break;
      }
      Debug.Log ("setPosition x = " + playerPos.x);
   }

   void setBorder ()
   {
      switch (area) 
      {
      case 1: // house
         min = -118.5f;
         max = -115.3f;
         break;
      case 2: // office
         min = -72.0f;
         max = -70.3f;
         break;
      case 3: // pool
         min = 0.0f;
         max = 0.0f;
         break;
      case 4: // main
         min = -24.0f;
         max = 196.0f;
         break;
      }      
   }

   void goToMain ()
   {
      if (area == 4) 
      {
         Debug.Log ("here 1");
         if (gameObject.tag == "toHouseFront") 
         {
            playerPos = GameObject.Find ("House").GetComponent<moveArea> ().orgPlayerPos;
            camPos    = GameObject.Find ("House").GetComponent<moveArea> ().orgCamPos;
         } 
         else if (gameObject.tag == "toOfficeFront") 
         {
            playerPos = GameObject.Find ("Office").GetComponent<moveArea> ().orgPlayerPos;
            camPos    = GameObject.Find ("Office").GetComponent<moveArea> ().orgCamPos;
            Debug.Log ("here 2");
         } 
         else 
         {
            playerPos = GameObject.Find ("Pool").GetComponent<moveArea> ().orgPlayerPos;
            camPos    = GameObject.Find ("Pool").GetComponent<moveArea> ().orgCamPos;
            Debug.Log ("here 3");
         } 
      }
      Debug.Log ("goToMain x = " + playerPos.x);
   }
}
