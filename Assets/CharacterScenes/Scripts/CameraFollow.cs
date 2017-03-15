using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // What the camera is going to follow
   public float smoothing = 7.5f; // 

   Vector3 offset; // Distance from target camera maintains

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
      Vector3 targetCamPos = target.position + offset;

      transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
   }
}
