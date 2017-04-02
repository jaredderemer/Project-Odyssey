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

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {

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
       
      // Check which way to throw
      if(this.GetComponent<playerController>().facingRight)
         coconutInstance.velocity = new Vector3(x, y, 0);
      else
         coconutInstance.velocity = new Vector3(-x, y, 0);
      
      Debug.Log(FireTransform.position + gameObject.transform.position);
   }
}
