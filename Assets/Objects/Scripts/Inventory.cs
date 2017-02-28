using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
   public const int numItemSlots = 4; // Number of inventory items possible
   public int[][] items = new int[numItemSlots][];
   
   // Testing new arrays
   public gameObject[] itemArray = new itemPickup[numItemSlots];
   
   public gameObject inventorySlot1;
   public gameObject inventorySlot2;
   
   public GameObject itemImage;
   public GameObject inventoryBar;
   
   
   //public Sprite coconut;
   //public Image myImage;
   
   // Use this for initialization
   void Start () 
   {
      
      itemArray[0] = inventorySlot1;
      itemArray[1] = inventorySlot2;
      
      // Initialize inventory item arrays
      /*items[0] = new int[2];
      items[1] = new int[2];
      items[2] = new int[2];
      items[3] = new int[2];*/
   }
   
   // Update is called once per frame
   void Update () 
   {
      
   }
   
   // testing new array type
   public void addItem(int itemId, int itemQuantity)
   {
      // Mabe ????
      //int slotId = itemArray[0].GetComponent<itemPickup.itemId>()
      
      if(itemArray[0] != null)
      {
         Debug.Log("Index 0 itemId: " + slotId);
      }
      
      for (int i = 0; i < itemArray.Length; i++)
      {
         // Look for empty cell
         if (itemArray[i].itemId == 0)
         {
            // Insert itemPickup object into array
            //itemArray[i] = newItem;
            Debug.Log("found an empty cell");
            Debug.Log("Setting inventory slot values");
            
            itemArray[i].itemId = itemId;
            itemArray[i].itemQuantity = itemQuantity;
            
            
             return;
         }
         
         // Look for same item to increase quantity
         else if(itemArray[i].itemId == itemId)
         {
            itemArray[i].itemQuantity += itemQuantity;
            return;
         }
      }
      
      
   }
   
   // Add item to the player inventory
   /*public void addItem(int itemId, int itemQuantity)
   {
      for (int i = 0; i < items.Length; i++)
      {
         // Look for empty cell
         if (items[i][0] == 0)
         {
            items[i][0] = itemId;
            items[i][1] = itemQuantity;
            
            displayImage(items[i], i);
            
            Debug.Log("Adding itemId: " + items[i][0] + "  quantity: " + items[i][1]);
             return;
         }
         
         // Look for same item to increase quantity
         else if(items[i][0] == itemId)
         {
            items[i][1] += itemQuantity;
            Debug.Log("Adding itemId: " + items[i][0] + "  new quantity: " + items[i][1]);
            return;
         }
      }
   }*/
   
   /*public void displayImage (int[] item, int itemPosition)
   {
      myImage = GetComponent<Image>();
      // Check itemId
      switch(item[0])
      {
         case 1:
            myImage.Sprite = coconut;
            break;
         default:
            break;
      }
      
      Instantiate(itemImage, new Vector3 (41.0f, 32.0f, 0), Quaternion.identity, inventoryBar.transform);
   }*/
   
   // Remove Item from player inventory
   public void removeItem (int itemToRemove)
   {
      for (int i = 0; i < items.Length; i++)
      {
         if (items[i][0] == itemToRemove)
         {
             return;
         }
      }
   }

    /*public void addItem(int objectId, int ammoCount)
    {
        if (coconuts < 99)
            coconuts += ammoCount;
        // keeping ammo cap to 99

    }*/
}
