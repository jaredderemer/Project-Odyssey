using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttacks : MonoBehaviour 
{

    public int hasStick;
    public Rigidbody coconut;
    public Transform FireTransform;
    private string Fire_Button;
    public int x;
    public int y;
    private float nextMelee;
    private float nextThrow;

	// Use this for initialization
	void Start () 
   {
      myAnim = transform.root.GetComponent<Animator>(); // Animator on the character itself	
      nextMelee = 0f;
      nextThrow = 0f;
	}
	
	// Update is called once per frame
	void Update () 
   {

	}

    

    
   void meleeAttack()
   {
      if(hasStick == 1)
      {
         float charMelee = Input.GetAxis("Fire1"); // Fire1 is the Right Alt key and Left Mouse

         if (charMelee > 0f && nextMelee < Time.time)
         {
            myAnim.SetTrigger("CharMelee");
            nextMelee = Time.time + meleeRate;
         }
      }
   }


   // Creates a coconut infront of player
   public void rangeAttack()
   {
      // Check if coconuts are available
      if(GetComponent<playerAmmo>().coconuts > 0)
      {
         float charThrow = Input.GetAxis("Fire2"); // Fire2 is the Left Alt key and Right Mouse

         if (charThrow > 0f && nextThrow < Time.time)
         {
            myAnim.SetTrigger("CharRange");
            nextThrow = Time.time + throwRate;
            
            Rigidbody coconutInstance = Instantiate(coconut, 
                                                    FireTransform.position + gameObject.transform.position,
                                                    FireTransform.rotation) 
                                        as Rigidbody;
       
            // Check which way to throw
            if(this.GetComponent<playerController>().facingRight)
            {
               coconutInstance.velocity = new Vector3(x, y, 0);
            }
            else
            {
               coconutInstance.velocity = new Vector3(-x, y, 0);
            }
         
            // Subtract coconut from ammo
            GetComponent<playerAmmo>().ammoUse();
         }
      }
   }
}
