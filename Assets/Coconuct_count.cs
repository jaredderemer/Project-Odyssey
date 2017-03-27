using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coconuct_count : MonoBehaviour
{
    int amount;
    public Text coco;

    // Use this for initialization
    void Start()
    {
        amount = 0;
        addCoconut(20);
    }

    // Updates the score of that the player earned
    public void addCoconut(int coconutsEarned)
    {
        amount += coconutsEarned;
        coco.text = string.Format(amount.ToString());
    }

    void Update()
    {

    }

    
}