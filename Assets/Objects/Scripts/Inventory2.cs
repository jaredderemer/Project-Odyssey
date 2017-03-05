using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Defines the Inventory structure
struct Inv
{
   public int itemID,
              quantity;
    public Inv(int a, int b)
    {
        itemID   = a;
        quantity = b;
    }            
}

public class Inventory2 : MonoBehaviour 
{  
  public const int numItemSlots = 4;       // Number of inventory items possible
  //public Inv[] inventory = new Inv[numItemSlots]; // Creates the Inventory Array 

  static Inv[] inventory = new Inv[4];

  // DELETE AFER TEST IS DONE
 /* void Update()
  {
      for (int i = 0; i < numItemSlots; i++)
      {
          Debug.Log(inventory[i].itemID);
          Debug.Log(inventory[i].quantity);
          Debug.Log(i);
      }
  }*/



   // Adds an item to the list, returns a message if successful
   public int addItem(int itemID, int itemQuantity)
   { 
      
      for (int i = 0; i < numItemSlots; i++)
      {
         // Look for empty cell
         if (inventory[i].itemID == 0)
         {
            Debug.Log("found an empty cell");
            Debug.Log("Setting inventory slot values");

            Debug.Log(inventory[i].itemID);
            inventory[i].itemID = itemID;
            inventory[i].quantity += itemQuantity;
            return 1;  // Returns 0 if the item has been placed.

         }
         // Look for same item to increase quantity
         else if (inventory[i].itemID == itemID)
         {
             inventory[i].quantity += itemQuantity;
             return 1;  // Returns 0 if the item has been placed.
         }

      }

      return 0;  // Returns 0 if the item has NOT been placed.
   }
   
   // Removes an item to the list, returns a message if successful
   public int removeItem(int itemID)
   {   
      for (int i = 0; i < numItemSlots; i++)
      {
         // Looks for item in the inventory and consumes it
         if (inventory[i].itemID == itemID)
         {
            if (inventory[i].quantity == 1)
            {
               inventory[i].itemID = 0;
               sortlist(i);
            }
            inventory[i].quantity -= 1;
         }
         else
         {
                 print("Item not found");
                 return 0; 
         }
      }
      return 1;  // Returns 1 if the item has been placed.
   }
      

   // Sorts the inventory after consuming an item.
   public void sortlist(int i)
   {
       print("SORTING!!!!");
   }

}



/************************************
Item ID  ------- Item Name 
000  ------------ empty
001  ------------ coconut
002  ------------
003  ------------
004  ------------
005  ------------
006  ------------
007  ------------

*************************************/