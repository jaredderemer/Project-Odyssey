/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      02/24/17  15:32                                              *
*                                                                              *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // What the camera is going to follow
   public float smoothing = 7.5f; // 
    
   public float edgeLeft;
   public float edgeRight;

   private float halfWidth;
   private float maxPosX;
   private float minPosX;

   Vector3 offset; // Distance from target camera maintains
   Vector3 targetCamPos;

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
      if (target.position.x >= maxPosX) 
      {
         targetCamPos = new Vector3 (maxPosX, transform.position.y, transform.position.z);
      } 
      else if (target.position.x <= minPosX) 
      {
         targetCamPos = new Vector3 (minPosX, transform.position.y, transform.position.z);
      }
      else 
      {
         targetCamPos = target.position + offset;
      }

      transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
  }
}
