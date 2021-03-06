﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*************************************************
 *---Nicholas Oliver's Inventory Script---
 *----------------------------------------
 *~~The Script holds the items in a statically
 *Allocated array. The code manages the inventory
 *size, and returns error messages to caller
 *if full or empty. 
 *----------------------------------------
 *~~The inventory script relies on the use of 
 *"Unique" item ID's to work. The ID's are 
 *Assigned on the itemPickup.cs script. 
 *The default value of '0' is for an empty
 *slot. The script will also rely on the 
 *said script to give the amount of an object 
 *was picked up. This is in case we use a 
 *cluster of items found as multples of 
 *a another item.  The itemPickup.cs will
 *automatically pass the the correct item
 *object, however, if the IDs are wrong, then
 *there might be a risk of a game object being
 *gone forever. Please use make sure the IDs are
 *UNIQUE.
 *----------------------------------------
 *------------NOTE------------------------
 *----------------------------------------
 *~~There is a list of itemIDs on the bottom 
 *of this script so we can keep track of what
 *items are using what ID's. If prefabs are 
 *done properly then there will never be an
 *issue of losing an item.
 ************************************************/



// Defines the Inventory structure
public struct Inv
{
   public        int itemID,     // Identifies the item
                     quantity;   // Amount of the item on hand
   public GameObject itemObject; // What is the object

    public Inv(int a, int b, GameObject c)
    {
        itemID     = a;
        quantity   = b;
        itemObject = c;
    }            
}

public class Inventory2 : MonoBehaviour 
{  
  public const int numItemSlots = 4;    // Number of inventory items possible

  public Inv[] inventory  = new Inv[numItemSlots];  // Creates the Array
  public Transform[] slot = new Transform[numItemSlots];

  
     
   // Adds an item to the list, returns a message if successful
   public int addItem(int itemID, int itemQuantity, GameObject itemObject, Transform itemTran)
   { 
      
      for (int i = 0; i < numItemSlots; i++)
      {
         // Look for empty cell
         if (inventory[i].itemID == 0)
         {
            itemObject.transform.localPosition = new Vector3(0, 0, 0);
            itemObject.transform.position      = new Vector3(0, 0, 0);
            inventory[i].itemID     = itemID;
            inventory[i].quantity  += itemQuantity;
            inventory[i].itemObject = itemObject;
            inventory[i].itemObject.transform.parent   = slot[i];
            inventory[i].itemObject.transform.localPosition = itemTran.position;
            inventory[i].itemObject.transform.localScale = itemTran.localScale;

            return 1;  // Returns 1 if the item has been placed.
         }
         // Look for same item to increase quantity
         else if (inventory[i].itemID == itemID)
         {
             inventory[i].quantity += itemQuantity;
             return 1;  // Returns 1 if the item has been placed.
         }

      }

      return 0;  // Returns 0 if the item has NOT been placed.
   }
   


   // Removes an item to the list, returns a message if successful
   public int removeItem(int itemID)
   {
      Debug.Log("Looking for ID: " + itemID);
      Debug.Log("--------------------------");
      Debug.Log("slot 1: " + inventory[0].itemID + ", " + inventory[0].quantity);
      Debug.Log("slot 2: " + inventory[1].itemID + ", " + inventory[1].quantity);
      Debug.Log("slot 3: " + inventory[2].itemID + ", " + inventory[2].quantity);
      Debug.Log("slot 4: " + inventory[3].itemID + ", " + inventory[3].quantity);
      Debug.Log("--------------------------");
      
      bool test1;
      int test2;
      
      for (int i = 0; i < numItemSlots; i++)
      {
         // Looks for item in the inventory and consumes it
         if (inventory[i].itemID == itemID)
         {
            // Check for single item in inventory
            if (inventory[i].quantity == 1)
            {
               // Empty the inventory slot and sort list
               sortList(i);
               return 1;
            }
            else if(inventory[i].quantity > 1)
            {
               // Decrement the quantity
               inventory[i].quantity -= 1;
               return 1;
            }
         }
         if (i == (numItemSlots - 1))
         {
             Debug.Log("Item not found"); 
             return 0;     
         }
      }
      return 1;  // Returns 1 if the item has been placed.
   }
   
   // Check if item is present in inventory
   public bool checkInventory(int itemID)
   {
      for (int i = 0; i < numItemSlots; i++)
      {
         // Looks for item in the inventory
         if (inventory[i].itemID == itemID)
         {
            if (inventory[i].quantity >= 1)
            {
               return true;
            }
         }
         
         // If last cell, then item not found
         if (i == (numItemSlots - 1))
         {
             return false;     
         }
      }
      return true;
   }
      
   // Sorts the inventory after consuming an item.
   public void sortList(int i)
   {
       Inv temp;

       for (; (i < (numItemSlots - 1)) && (inventory[i + 1].itemID != 0); i++)
       {
           temp = inventory[i];
           inventory[i] = inventory[i + 1];
           inventory[i + 1] = temp;
           inventory[i].itemObject.transform.parent       = slot[i];
           inventory[i].itemObject.transform.position     = slot[i].position;
           inventory[i + 1].itemObject.transform.parent   = slot[i + 1];
           inventory[i + 1].itemObject.transform.position = slot[i + 1].position;
 
       }
       inventory[i].itemID = 0;
       inventory[i].quantity = 0;
       Destroy(inventory[i].itemObject);
   }


   // Drops the first item on the inventory
   public void dropItem()
   {
       // Player drops an item

      if (inventory[0].itemID != 0)
      {
         removeItem (inventory[0].itemID);
      }
      else
      {
         print("Iventory is empty, CAN'T drop!!");
      } 
   }

}



/************************************
Item ID  ------- Item Name 
000  ------------ empty
001  ------------ coconut
002  ------------ KeyItem
003  ------------ Map
004  ------------ Gate Key
005  ------------ Bedroom Key
006  ------------ Secretary Key
007  ------------ Poolhouse Key
*************************************/