using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut : MonoBehaviour
{
   public Transform target;
    
   void LateUpdate ()
   {
      if (target.position.x < -4.9f && target.position.x > -12.9f)
      {
         transform.LookAt (target.transform);
      }
   }
}