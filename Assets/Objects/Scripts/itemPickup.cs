using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPickup : MonoBehaviour 
{
   public int itemID;
   public int itemQuantity;
   public GameObject itemObject;
   GameObject prefab;
   public Transform itemTran;
    	
    void Start()
    {
        //itemObject = gameObject;

        prefab = (GameObject)Resources.Load(itemObject.name);
        //itemTran = itemObject.transform;
    }

   // Add item to player inventory
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
          GameObject screenObject = Instantiate(itemObject);
          //Debug.Log(other.GetComponent<Inventory2>().addItem(itemID, itemQuantity));
          if (other.GetComponent<Inventory2>().addItem(itemID, itemQuantity, screenObject, itemTran) == 0)
              print("Pickup failed..inventory full");
          else
              Destroy(gameObject);
         
      }
   }
}
