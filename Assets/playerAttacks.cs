using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttacks : MonoBehaviour 
{

    public int hasStick; // player's power, will get used by 2 other scripts 
                      // for reference. Stick and enemy to get power and
                      // see how much damage to do. 

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    

    // Allows the player to melee
    // **** missing button input ****
    // ****       NOTE        ****
    // ** the stick will have an onTrigger and
    // ** will call it's own script to hurt enemies.
    // ** it must detect colision so that's Nick's job
    // ** to apply damage on the monkey.
   void meleeAttack()
   {
      if(hasStick == 1)
      {
          /// ATTACK!!
      }

   }
}
