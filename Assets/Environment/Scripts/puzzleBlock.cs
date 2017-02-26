using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleBlock : MonoBehaviour {

   public GameObject block;
   public int damage;
   private bool isActive;

   private int hitCount;

	// Use this for initialization
	void Start () 
   {
      isActive = false;
      hitCount = 0;
	}
	
   void OnTriggerEnter(Collider collider)
   {
      if (collider.tag == "Player") 
      {
         Debug.Log ("first " + hitCount);
         hitCount += 1;
         Debug.Log ("Second " + hitCount);
         makeBlock ();
      }
//      if (collider.tag == "Player" && !isActive) 
//      {
//         yield return new WaitForSeconds (0.5f);
//         tile.SetActive (true);
//         isActive = true;
//      }
   }

   void makeBlock()
   {
      if (hitCount == damage) 
      {
         Instantiate (block, 
            new Vector3 (transform.position.x + 0.5f, 
                         transform.position.y + 1.5f, 
                         transform.position.z), 
            Quaternion.identity);
         Destroy (gameObject);
      }   
   }
}
