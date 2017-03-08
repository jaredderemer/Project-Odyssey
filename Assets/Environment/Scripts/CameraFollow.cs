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

   private float offsetX;       // Distance from target camera maintains
   private Vector3 targetCamPos; //

   // Use this for initialization
   void Start ()
   {
      //offsetX   = 10.0f;
      halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
      maxPosX   = edgeRight - halfWidth;
      minPosX   = edgeLeft - halfWidth;

   }

   void FixedUpdate()
   {
      if (target.position.x >= maxPosX)
      {
          targetCamPos = new Vector3 (maxPosX,
                                      target.position.y,
                                      transform.position.z);
         targetCamPos.x = maxPosX + offsetX;
      }
      else if (target.position.x <= minPosX)
      {
         targetCamPos.x = minPosX;
         targetCamPos = new Vector3 (minPosX,
                                     target.position.y,
                                     transform.position.z);
      }
      else
      {
         //targetCamPos = target.position + offset;
          targetCamPos = new Vector3(target.position.x,
                                     //target.position.y + 7.0f,
            transform.position.y,
                                     transform.position.z);

         //if (target.position.y >= maxPosY)
         {

         }

      }

      transform.position = Vector3.Lerp(transform.position,
                                        targetCamPos,
                                        smoothing * Time.deltaTime);
  }
}
