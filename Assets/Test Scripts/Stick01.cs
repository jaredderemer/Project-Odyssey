using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
// This is for the pickup of the stick, 
// not when it is used for attacking
/// </summary>
public class Stick01 : MonoBehaviour 
{
    public int powerAmount;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // calls the playerAttack.cs to add power
    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
          other.GetComponent<playerAttacks>().hasStick = 1;
          Destroy(gameObject);
       }

    }
}
