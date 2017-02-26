using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleBlock : MonoBehaviour {

   public GameObject tile;

   private Color[] colorSet = new Color[4];
   private Renderer[] rList;
   private int index;

	// Use this for initialization
	void Start () {
      colorSet[0] = Color.red;
      colorSet[1] = Color.blue;
      colorSet[2] = Color.cyan;
      colorSet[3] = Color.yellow;

      index = Random.Range (0, colorSet.Length);
      rList = gameObject.GetComponentsInChildren<Renderer> ();

      foreach (Renderer r in rList) 
      {
         r.material.color = colorSet [index];
      }
         
   
      Debug.Log (colorSet[index]);

	}
	
   IEnumerator OnTriggerEnter(Collider collider)
   {
      if (collider.tag == "Player") 
      {
         yield return new WaitForSeconds (0.5f);
         tile.SetActive (true);
      }
   }
	// Update is called once per frame
	void Update () {
		
	}
}
