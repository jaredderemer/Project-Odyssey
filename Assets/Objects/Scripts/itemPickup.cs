using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPickup : MonoBehaviour 
{
   public int itemID;
   public int itemQuantity;
    	
   // Add item to player inventory
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
          //Debug.Log(other.GetComponent<Inventory2>().addItem(itemID, itemQuantity));
          if (other.GetComponent<Inventory2>().addItem(itemID, itemQuantity) == 1)
          {
              Destroy(gameObject);
          }
          else
          {
              print("Pickup failed..inventory full");
          }
      }
   }
}
