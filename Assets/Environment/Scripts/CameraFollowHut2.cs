/******************************************************************************
* Author            MM/DD/YY HH24:MM   Description                            *
* Jonathan Rigsby   02/04/17 15:30     Focus on and follow an object          *
* Juju Moong        03/02/17 1:15      Move camera up and down                *
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut2 : MonoBehaviour
{
   public float cameraLeftLimit;
   public float cameraRightLimit;
   public float cameraLowerLimit;
   public float cameraUpperLimit;
   public float smoothing;

   public Transform target;

   private float cameraOffset;

   private Vector3 targetCamPos;

   void Start ()
   {
      cameraOffset = transform.position.y - target.position.y;
   }

   void LateUpdate ()
   {
      // Pivot camera to follow the object
      if (target.position.x >= cameraLeftLimit 
          && target.position.x <= cameraRightLimit) 
      {  
         transform.LookAt (target.transform);
      }

      // Move camera up/down to follow the object
      if (target.position.y >= cameraLowerLimit 
          || target.position.y <= cameraUpperLimit)
      {
            targetCamPos       = new Vector3 (transform.position.x,
                                              target.position.y + cameraOffset,
                                              transform.position.z);
            transform.position = Vector3.Lerp (transform.position,
                                               targetCamPos,
                                               smoothing * Time.deltaTime);
      }
   }
}
