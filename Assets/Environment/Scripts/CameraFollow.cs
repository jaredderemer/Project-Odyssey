/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32      Make the camera follows the player      *
*                                      Set X endpoints so that the camera      *
*                                      won't go pass them                      *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;      // What the camera is going to follow

   public float edgeLeft;
   public float edgeRight;
   public float smoothing;       // 

   private float halfWidth;
   private float maxPosX;
   private float minPosX;

   private Vector3 offset;       // Distance from target camera maintains
   private Vector3 targetCamPos; // 

   // Use this for initialization
   void Start ()
   {
      offset    = transform.position - target.position;
      halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
      maxPosX   = edgeRight - halfWidth;
      minPosX   = edgeLeft - halfWidth;

   }
    
   void FixedUpdate()
   {
      if (target != null) 
      {
         if (target.position.x >= maxPosX) 
         {
            targetCamPos = new Vector3 (maxPosX, 
                                        target.position.y + offset.y, 
                                        target.position.z + offset.z);
         } 
         else if (target.position.x <= minPosX) 
         {
            targetCamPos = new Vector3 (minPosX, 
                                        target.position.y + offset.y, 
                                        target.position.z + offset.z);
         } 
         else 
         {
            targetCamPos = target.position + offset;
         }

         transform.position = Vector3.Lerp (transform.position, 
                                            targetCamPos, 
                                            smoothing * Time.deltaTime);
      }
  }
}
