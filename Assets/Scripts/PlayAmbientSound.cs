using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbientSound : MonoBehaviour {
   public AudioClip ambientSound;

   public float minPosition;
   public float maxPosition;
   public Transform target;

   void Update ()
   {
      if (target.position.x >= minPosition && target.position.x <= maxPosition) 
      {
         AudioSource.PlayClipAtPoint (ambientSound, target.position, 0.3f);
      } 
   }
}
