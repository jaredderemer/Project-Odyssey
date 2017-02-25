/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32                                              *
*                                                                              *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeredMovement : MonoBehaviour {
   
   public Transform lift;  // Manipulated when button is triggered
   public float length;    // Length required to move lift up
   public float speed;     // Speed required to move lift up

   private float min;      // Minimum Y position to move down
   private float max;      // Maximum Y position to move up
   private Vector3 newPos; // New position of the tile
   private bool isClicked; // Check if the button is clicked

   void Start () 
   {
      min       = lift.position.y;
      max       = lift.position.y + length;
      isClicked = false;
   }

   void OnTriggerEnter (Collider collider)
   {
      if (collider.tag == "Player") // NOTE: CHANGE TO WEAPON? WHEN COCONUTS ARE READY
      {
         isClicked = true;
      }
   }

   void Update ()
   {      
      if (isClicked) 
      {
         StartCoroutine(animateTile());
      }
   }

   /***************************************************************************
   * animateTile                                                              *
   * Tile is moved up, waits for a few seconds, and then is moved down        *                                                                        *
   ***************************************************************************/
   IEnumerator animateTile ()
   {
      // Get a new Y position and move the tile
      newPos        = updateNewPosition(max);
      lift.position = Vector3.Lerp(lift.position, newPos, speed * Time.deltaTime);

      // Waits 5 seconds before moving down
      yield return new WaitForSeconds(5.0f);

      newPos        = updateNewPosition(min);
      lift.position = Vector3.Lerp(lift.position, newPos, speed * Time.deltaTime);

      // Set it back to false so that the tile won't be constantly moving
      isClicked     = false;
   }

   /***************************************************************************
   * updateNewPosition                                                        *
   * Get a new Y position                                                     *
   ***************************************************************************/
   Vector3 updateNewPosition(float newY)
   {
      // Returns the new position for the tile
      return (new Vector3(lift.position.x, newY, lift.position.z));
   }
}
