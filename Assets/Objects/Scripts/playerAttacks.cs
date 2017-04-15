using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttacks : MonoBehaviour 
{

    public int hasStick;
    public Rigidbody coconut;
    public int x;
    public int y;
    
    private float nextMelee;
    public float meleeRate; // Can change speed based off which weapon is used; useful for stick vs branch
    private float meleeDamage;
    
    private float nextThrow;
    public float throwRate;
    
    private GameObject throwHand;
    private Vector3 throwOffset;
    private float counterBalance;
    
    private GameObject stick;
    Animator myAnim;

	// Use this for initialization
	void Start () 
   {
      myAnim = transform.root.GetComponent<Animator>(); // Animator on the character itself	
  		stick = GameObject.Find("ATK_Stick_1");
  		meleeDamage = stick.GetComponent<damageAmount>().damage;
  		stick.GetComponent<damageAmount>().damage = 0.0f;
      nextMelee = 0f;
      nextThrow = 0f;
      throwOffset.Set(0.0f, 0.0f, 0.13f);
      counterBalance = -1.79f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
   {
      meleeAttack();
      rangeAttack();
	}

    

    
   public void meleeAttack()
   {
      if(hasStick == 1)
      {
         float charMelee = Input.GetAxis("Fire1"); // Fire1 is the Right Alt key and Left Mouse
         
         if (charMelee > 0f && nextMelee < Time.time)
         {
            stick.GetComponent<damageAmount>().damage = meleeDamage;
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
            
                  
            // Check which way to throw and throw
            if(this.GetComponent<PlayerControllerTest>().facingRight)
            {
               Rigidbody coconutInstance = Instantiate(coconut, 
                                                    throwHand.transform.position + throwOffset,
                                                    Quaternion.identity)
                                        as Rigidbody;
                                        
               coconutInstance.velocity = new Vector3(x, y, counterBalance);
            }
            else
            {
               Rigidbody coconutInstance = Instantiate(coconut, 
                                                    throwHand.transform.position + (throwOffset * -1.0f),
                                                    Quaternion.identity)
                                        as Rigidbody;
                                        
               coconutInstance.velocity = new Vector3(-x, y, counterBalance * -1.0f);
            }
         
            // Subtract coconut from ammo
            GetComponent<playerAmmo>().ammoUse();
         }
      }
   }
}
