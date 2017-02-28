/****************************************************************************** 
* Author            MM/DD/YY HH24:MM   Description                            * 
* Jonathan Rigsby   02/04/17 15:30     Focus on and follow an object          *
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut : MonoBehaviour
{
   public Transform target;
   
   public float cameraLeftLimit;
   public float cameraRightLimit;
   public float cameraLowerLimit;
   public float cameraUpperLimit;
   
   void Start ()
   {
      float cameraOffset = transform.position.y - target.position.y;
   }
 
   // Updates the coordinates the camera is focused on
   void LateUpdate ()
   {
      // Pivot the camera to follow the object
      if (target.position.x >= cameraLeftLimit && target.position.x <= cameraRightLimit)
      {
         transform.LookAt (target.transform);
      }
      
      if ((target.position.y + cameraOffset) > transform.position.y && 
          (target.position.y + cameraOffset) < cameraUpperLimit)
      {
         transform.Translate (0.0f, target.position.y - cameraOffset, 0.0f);
      }
      else if ((target.position.y + cameraOffset) < transform.position.y && 
               (target.position.y + cameraOffset) > cameraLowerLimit)
      {
         transform.Translate (0.0f, cameraOffset - target.position.y, 0.0f);
      }
      
      // Move the camera up and down to follow the object
     //if (target.position.y >= playerLowerEdge && 
       //   target.position.y <= playerUpperEdge &&
      //    transform.position.y >= cameraLowerEdge && 
      //    transform.position.y <= cameraUpperEdge)
    //  {
     //    Debug.Log("move if");
     //    transform.Translate (0.0f, transform.position.y-target.position.y, 0.0f);
     // }
   }
}