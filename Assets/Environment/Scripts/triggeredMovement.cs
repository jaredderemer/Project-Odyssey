/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      When the button is hit, move the tile   *
*                                                                              *
* TYRING TO COMBINE WITH CART CONTROLLER BECAUSE MOST OF THE CODE ARE THE SAME *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeredMovement : MonoBehaviour {

   public float length;    // Length required to move
   public float speed;     // Speed required to move

   public Transform lift;  // Manipulated when button is triggered

   private bool isTriggered; // Check if the button is triggered

   private float min;      // Minimum Y position to move down
   private float max;      // Maximum Y position to move up

   private Vector3 newPos; // New position of the tile


   void Start () 
   {
      min       = lift.position.y;
      max       = lift.position.y + length;
      isTriggered = false;
   }

   void OnTriggerEnter (Collider collider)
   {
      if (collider.tag == "Player") // NOTE: CHANGE TO WEAPON? WHEN COCONUTS ARE READY
      {
         isTriggered = true;
         gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 120.0f);
      }
   }

   void Update ()
   {      
      if (isTriggered) 
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
      newPos        = updateYPosition(max);
      lift.position = Vector3.Lerp(lift.position, newPos, speed * Time.deltaTime);

      // Waits 5 seconds before moving down
      yield return new WaitForSeconds(5.0f);

      newPos        = updateYPosition(min);
      lift.position = Vector3.Lerp(lift.position, newPos, speed * Time.deltaTime);

      // Set it back to false so that the tile won't be constantly moving
      isTriggered     = false;
   }

   /***************************************************************************
   * updateNewPosition                                                        *
   * Get a new Y position                                                     *
   ***************************************************************************/
   Vector3 updateYPosition(float newY)
   {
      // Returns the new position for the tile
      return (new Vector3(lift.position.x, newY, lift.position.z));
   }
}
