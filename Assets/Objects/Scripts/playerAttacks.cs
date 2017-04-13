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
    public float meleeRate; // Can change speed based off which weapon is used; useful for stick vs branch
    
    private float nextThrow;
    public float throwRate;
    
    private GameObject throwHand;
    public Transform throwOffset;
    
    Animator myAnim;

	// Use this for initialization
	void Start () 
   {
      myAnim = transform.root.GetComponent<Animator>(); // Animator on the character itself	
      nextMelee = 0f;
      nextThrow = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
   {
      meleeAttack();
      rangeAttack();
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
      throwHand = GameObject.FindWithTag("throwHand");
      
      // Check if coconuts are available
      if(GetComponent<playerAmmo>().coconuts > 0)
      {
         float charThrow = Input.GetAxis("Fire2"); // Fire2 is the Left Alt key and Right Mouse

         if (charThrow > 0f && nextThrow < Time.time)
         {
            myAnim.SetTrigger("CharRange");
            nextThrow = Time.time + throwRate;
            
            Rigidbody coconutInstance = Instantiate(coconut, 
                                                    throwHand.transform.position + throwOffset.position,
                                                    Quaternion.identity)
                                        as Rigidbody;
       
            // Check which way to throw
            if(this.GetComponent<PlayerControllerTest>().facingRight)
            {
               coconutInstance.velocity = new Vector3(x, y, 0);
            }
            else
            {
               coconutInstance.velocity = new Vector3(-x, y, 0);
               print("THROW LEFT JOHN!!!!");
            }
         
            // Subtract coconut from ammo
            GetComponent<playerAmmo>().ammoUse();
         }
      }
   }
}
