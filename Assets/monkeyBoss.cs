using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyBoss : MonoBehaviour
{
   public GameObject[] objList;
   private int index;

	public void dropItem()
   {
      index = (int)Random.Range (0, objList.Length);
      Instantiate (objList [index], 
                   new Vector3 (transform.position.x, 
                                transform.position.y + 0.7f, 
                                transform.position.z + 0.132f), 
                   Quaternion.identity);
   }
}
