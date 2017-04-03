using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDTest : MonoBehaviour
{
    [HideInInspector] public int points;

    public Text Score;

    // Use this for initialization
    void Start()
    {
        points = globalController.Instance.playerScore;
        updateScore(0);
    }

    // Updates the score of that the player earned
    public void updateScore(int pointsEarned)
    {
        points += pointsEarned;
        string text = string.Format("Score: " + points.ToString());
        Score.text = text;
    }

    public void savePlayerScore()
    {
       globalController.Instance.playerScore = points;
    }

}