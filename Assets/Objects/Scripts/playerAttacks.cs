using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttacks : MonoBehaviour 
{

    public int hasStick;
    public Rigidbody coconut;
    public Transform FireTransform;
    public Text AmmoText;
    GameObject Ammo;
    private string Fire_Button;
    public int coconuts;
    public int x;
    public int y;

	// Use this for initialization
	void Start () 
    {
        Ammo = GameObject.Find("Ammo");
        ammoPickup(20);
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
       if (coconuts > 0)
       {
           Rigidbody coconutInstance = Instantiate(coconut, FireTransform.position + gameObject.transform.position, FireTransform.rotation) as Rigidbody;
           coconutInstance.velocity = new Vector3(x, y, 0);
           updateAmmo(-1);
       }
       else
           print("No more coconuts");
   }


    /// NOTE TO MYSELF,NICK, COMBINE THESE TWO LATER!!!!

   // Picks up coconuts
   public void ammoPickup(int ammoCount)
   {
       if (coconuts < 99)
       {
           updateAmmo(ammoCount);
       }
       // keeping ammo cap to 99

   }

   public void updateAmmo(int ammoCount)
   {
       coconuts += ammoCount;
       string text = string.Format(coconuts.ToString());
       AmmoText.text = text;
   }
}
