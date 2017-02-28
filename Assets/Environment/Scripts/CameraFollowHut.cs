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
   
   public float cameraLeftEdge;
   public float cameraRightEdge;
   public float cameraLowerEdge;
   public float cameraUpperEdge;
   public float playerLowerEdge;
   public float playerUpperEdge;
 
   // Updates the coordinates the camera is focused on
   void LateUpdate ()
   {
      // Pivot the camera to follow the object
      if (target.position.x >= cameraLeftEdge && target.position.x <= cameraRightEdge)
      {
         transform.LookAt (target.transform);
      }
      
      // Move the camera up and down to follow the object
      if (target.position.y >= playerLowerEdge && 
          target.position.y <= playerUpperEdge &&
          transform.position.y >= cameraLowerEdge && 
          transform.position.y <= cameraUpperEdge)
      {
         Debug.Log("move if");
         transform.Translate (0.0f, transform.position.y-target.position.y, 0.0f);
      }
   }
}