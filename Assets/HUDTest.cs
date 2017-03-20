using UnityEngine;
using System.Collections;

public class HUDTest : MonoBehaviour
{
    float deltaTime = 0.0f;
    int points;


    // Use this for initialization
    void Start()
    {
        points = 0;
        updateScore(0);
    }

    // Updates the score of that the player earned
    public void updateScore(int pointsEarned)
    {
        points += pointsEarned;
        
    }

    void Update()
    {

    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 20, w, h * 6 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 8 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        string text = string.Format("Score: " + points);
        GUI.Label(rect, text, style);
    }
}