using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTest : MonoBehaviour
{
   public Transform target;
   public float smoothing;

   private Vector3 offset;

   // Use this for initialization
   void Start()
   {
      offset = transform.position - target.position;
   }

   // Update is called once per frame
   void Update()
   {

   }

   void FixedUpdate()
   {
      if (target != null)
      {
         Vector3 targetCamPos = target.position + offset;
         transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
      }
   }
}