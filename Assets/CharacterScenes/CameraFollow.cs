using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   /*public Transform target; // What the camera is going to follow
   public float smoothing = 7.5f; // 


   public float edgeLeft;
   public float edgeRight;
   float halfWidth;
   float maxPosition;
   float minPosition;

   Vector3 offset; // Distance from target camera maintains*/
   
   public float dampTime = 0.2f;
   public GameObject player;
   [HideInInspector] public Transform target;
   
   private Camera camera;
   private Vector3 moveVelocity;
   private Vector3 desiredPosition;
   
   /*// Use this for initialization
   void Start()
   {
      //offset = transform.position - target.position;
      halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
      maxPosition = edgeRight - halfWidth;
      minPosition = edgeLeft - halfWidth;
   }
   
   void FixedUpdate()
   {
      Vector3 targetCamPos = target.position;// + offset;

      // Juju's code for camera
      if (target.position.x >= maxPosition)
      {
         targetCamPos = new Vector3(maxPosition, transform.position.y, transform.position.z);
      }
      else if (target.position.x <= minPosition)
      {
         targetCamPos = new Vector3(minPosition, transform.position.y, transform.position.z);
      }
      else
      {
         targetCamPos = target.position;// + offset;
      }


      transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
   }*/
   
   private void Awake()
   {
      camera = GetComponentInChildren<Camera>();
   }
   
   private void FixedUpdate()
   {
      Move();
   }
   
   private void Move()
   {
      FindPosition();
      
      transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime
   }
   
   private void FindPosition()
   {
      Vector3 pos = new Vector3();
      
      pos = player.position;
      pos.y = transform.position.y;
      pos.x += 10; // Keeps camera slightly in front of player
      
      desiredPostion = pos;
   }
   
   public void StopCamera(Vector3 pos, bool freezeX, bool freezeY)
   {
      FindPosition();
      
      if (freezeX)
      {
         desiredPosition.x = pos.x;
      }
      
      if (freezeY)
      {
         desiredPosition.y = pos.y;
      }
      
      transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime
   }
}
