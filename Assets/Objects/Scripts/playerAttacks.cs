using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;   // DELETE
using System.IO;// DELETE

public class playerAttacks : MonoBehaviour 
{

    public int hasStick;
    public Rigidbody coconut;
    public Transform FireTransform;
    private string Fire_Button;

    

	// Use this for initialization
	void Start () 
    {
        var fileName = "Nicks Debugger.txt";

        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }

        var sr = File.CreateText(fileName);
        sr.WriteLine("This Is to test the Values of the Inventory. \n");
        sr.Close();
	}

    
   void meleeAttack()
   {
      if(hasStick == 1)
      {
          /// ATTACK!!
      }

   }


   // Creates a coconut infront of player
   public void rangeAttack()
   {
       Rigidbody coconutInstance = Instantiate(coconut, FireTransform.position + gameObject.transform.position, FireTransform.rotation) as Rigidbody;
       Debug.Log(FireTransform.position + gameObject.transform.position);
       //Instantiate(coconutInstance);
   }
}
