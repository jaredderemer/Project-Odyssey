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
           float cameraOffset;
           float yTranslate;
   
   void Start ()
   {
      cameraOffset = transform.position.y - target.position.y;
   }
 
   void LateUpdate ()
   {
      // Pivot camera to follow the object
      if (target.position.x >= cameraLeftLimit && target.position.x <= cameraRightLimit)
      {
         transform.LookAt (target.transform);
      }
      
      // Move camera up to follow the object
      if (target.position.y + cameraOffset > transform.position.y &&
          transform.position.y < cameraUpperLimit)
      {
         yTranslate = (cameraOffset + target.position.y) - transform.position.y;
         Debug.Log(yTranslate);
         Debug.Log("greater if");
         transform.Translate (0.0f, yTranslate, 0.0f);
      }
      // Move camera down to follow the object
      else if (target.position.y + cameraOffset < transform.position.y && 
                transform.position.y > cameraLowerLimit)
      {
         yTranslate = transform.position.y - (cameraOffset + target.position.y);
         Debug.Log(yTranslate);
         Debug.Log("lesser if");
         transform.Translate (0.0f, yTranslate, 0.0f);
      }
   }
}
