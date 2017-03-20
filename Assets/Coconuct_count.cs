using UnityEngine;
using System.Collections;

public class Coconuct_count : MonoBehaviour
{
    int amount;


    // Use this for initialization
    void Start()
    {
        amount = 0;
        addCoconut(0);
    }

    // Updates the score of that the player earned
    public void addCoconut(int coconutsEarned)
    {
        amount += coconutsEarned;

    }

    void Update()
    {

    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 525, w, h * 6 / 100);
        style.alignment = TextAnchor.LowerRight;
        style.fontSize = h * 5 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        string text = string.Format(" " + amount);
        GUI.Label(rect, text, style);
    }
}