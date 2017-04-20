using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class profanityFilter : MonoBehaviour
{
    // Checks a name to see if it has any inappropriate words within it
    public bool passesFilter(string name)
    {
        bool     passesFilter = true;
        string   nextFilterWord;
        StreamReader stream = new StreamReader("filter.txt", Encoding.Default);

        using (stream)
        {
            while (passesFilter && (nextFilterWord = stream.ReadLine()) != null)
            {
                print("LOOPIES!!!");
                if (Regex.IsMatch(name, nextFilterWord))
                {
                    print("BAD WORD FOUND!!");
                    passesFilter = false;
                }
            }
       }
       stream.Close();
       return passesFilter;
    }
}
