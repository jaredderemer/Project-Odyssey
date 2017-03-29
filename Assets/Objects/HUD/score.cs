using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

    int points;
    


	// Use this for initialization
	void Start () 
    {
        points = 0;
        updateScore(0);
	}
	
	// Update is called once per frame
	void Update () 
    {
	   	
	}


    // Updates the score of that the player earned
    void updateScore(int pointsEarned)
    {
        points += pointsEarned;
        //scoreText.text = "Score: " + points;
        gameObject.GetComponent<GUIText>().text = "Score: " + points;
    }
}
