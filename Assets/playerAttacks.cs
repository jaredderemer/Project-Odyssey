using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttacks : MonoBehaviour 
{

    public int hasStick;
    public Rigidbody coconut;
    public Transform FireTransform;
    private string Fire_Button;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
    //    Rigidbody coconutInstance = Instantiate(coconut, FireTransform.position, FireTransform.rotation) as Rigidbody;
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
       Rigidbody coconutInstance = Instantiate(coconut, FireTransform.position, FireTransform.rotation) as Rigidbody;
       Debug.Log(FireTransform.position);
       //Instantiate(coconutInstance);
   }
}
