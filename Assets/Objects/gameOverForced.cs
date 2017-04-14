using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverForced : MonoBehaviour 
{

    // This is a test script to force the game to go GAMEOVER for testing purposes.

	// Use this for initialization
	void Start () 
    {
        //gameObject.GetComponent<GameOver>().firstNameInput.text = "Nicholas";
        //gameObject.GetComponent<GameOver>().lastNameInput.text = "Oliver";
        gameObject.GetComponent<GameOver>().submitScore();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
