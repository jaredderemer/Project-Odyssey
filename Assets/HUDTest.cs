using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDTest : MonoBehaviour
{
    int points;

    public Text Score;

    // Use this for initialization
    void Start()
    {
        points = 45;
        updateScore(0);
    }

    // Updates the score of that the player earned
    public void updateScore(int pointsEarned)
    {
        print("Point: ");
        points += pointsEarned;
        string text = string.Format("Score: " + points.ToString());
        Score.text = text;
    }

    void Update()
    {

    }

}