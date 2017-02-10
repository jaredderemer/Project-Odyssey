using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
   public Transform target;

   public float smoothing = 5f;
   public float edgeLeft;
   public float edgeRight;

   float halfWidth;
   float maxPosition;
   float minPosition;

   Vector3 offset;
   Vector3 targetCamPos;

	// Use this for initialization
	void Start () 
   {
      offset      = transform.position - target.position;
      halfWidth   = Camera.main.orthographicSize * Screen.width / Screen.height;
      maxPosition = edgeRight - halfWidth;
      minPosition = edgeLeft - halfWidth;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
   {
      if (target.position.x >= maxPosition) 
      {
         targetCamPos = new Vector3 (maxPosition, transform.position.y, transform.position.z);
      } 
      else if (target.position.x <= minPosition) 
      {
         targetCamPos = new Vector3 (minPosition, transform.position.y, transform.position.z);
      }
      else 
      {
         targetCamPos = target.position + offset;
      }
      transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
   }
}
