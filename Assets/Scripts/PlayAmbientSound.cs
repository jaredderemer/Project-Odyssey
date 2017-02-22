using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbientSound : MonoBehaviour {
   public AudioClip ambientSound;

   public float minPosition;
   public float maxPosition;
   public int   musicON = 0; // This is a temp code to prevent a infinite creating FX -- Nick--
   public Transform target;

   void Update ()
   {
      if (target.position.x >= minPosition && target.position.x <= maxPosition && musicON == 0) 
      {
         musicON = 1;  // This is a temp code to prevent a infinite creating FX -- Nick--
         AudioSource.PlayClipAtPoint (ambientSound, target.position, 0.3f);
      } 
   }
}
