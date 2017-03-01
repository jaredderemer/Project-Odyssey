using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPickup : MonoBehaviour 
{
   public int itemId;
   public int itemQuantity = 0;
    

	// Use this for initialization
	void Start () 
	{
       
	}
	
	// Update is called once per frame
    void Update() 
	{   
       
	}
	
	// Add item to player inventory
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            //other.GetComponent<Inventory>().addItem(itemId, itemQuantity);
            Destroy(gameObject);
        }
	}
}
