/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Cart moves left/right when the player   *
*                                      collides with it                        *
*                                                                              *
* TYRING TO COMBINE W/ TRIGGEREDMOVEMENT 'CAUSE MOST OF THE CODE ARE THE SAME  *
* NEED TO GET RID OF SOME CODE. KEEPING THEM NOW FOR FUTURE REFERENCE          *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartController : MonoBehaviour {
   [HideInInspector]
   public bool isRight;     // Check the position of the object
   public float length;      // Length required to move
   public float speed;       // Speed required to move
  
   private AudioSource movingAS;

   private bool isTriggered; // Check if the object is triggered
   private bool musicOn;
   private float min;        // Minimum position to move
   private float max;        // Maximum position to move

   private Transform target; // The object to be moved along

   private Vector3 newPos;   // New position of the object
   private Vector3 offset;


   void Start () 
   {
      movingAS    = GetComponent<AudioSource> ();
      min         = transform.position.x;
      max         = transform.position.x + length;
      isTriggered = false;
      isRight     = false;
      target      = null;
      musicOn     = false;
   }
    
   void OnTriggerStay (Collider collider)
   {
      if (collider.tag == "Player")
      {
         isTriggered = true;
         target      = collider.transform;
         offset      = target.position - transform.position;
         if (!musicOn) 
         {
            musicOn = true;
            movingAS.Play ();
         }
      }
   }

   void OnTriggerExit(Collider collider)
   {
      isTriggered = false;
      target      = null;
      isRight     = !isRight;
      movingAS.Stop ();
      musicOn = false;
   }

   void Update ()
   {      
      if (isTriggered) 
      {
         // Move the object to the opposite direction
         if (isRight) 
         {
            newPos             = updateXPosition(min);
            transform.position = Vector3.Lerp(transform.position, 
                                              newPos, 
                                              speed * Time.deltaTime);
         } 
         else 
         {
            newPos             = updateXPosition(max);
            transform.position = Vector3.Lerp(transform.position, 
                                              newPos, 
                                              speed * Time.deltaTime);
         }

         // If any object is in touch with the moving object, take the object
         // with it whereever it moves
         if (target != null) 
         {
            target.position = transform.position + offset;
         }
      }
   }
      
   /***************************************************************************
   * updateNewPosition                                                        *
   * Get a new position                                                     *
   ***************************************************************************/
   Vector3 updateXPosition(float newX)
   {
      // Returns the new position for the object
      return (new Vector3(newX, transform.position.y, transform.position.z));
   }
}
