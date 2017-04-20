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
    private const int MAX_NAME_LENGTH = 20;


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
                nextFilterWord = nextFilterWord.ToUpper();
                if (Regex.IsMatch(name, nextFilterWord))
                {
                    print("BAD WORD FOUND!!");
                    passesFilter = false;
                    print("CUSS !@#$");
                }
            }
       }
            stream.Close();

        return passesFilter;
        }
        


    // Modifies a name and then checks that modified name
    // to see if it is valid.
    // Parmeters:
    // Unmodified name to be checked
    // Empty string that will be used for the name after it is modified
    public bool passesFormatCheck(string name, out string modifiedName)
    {
        bool isValid = false;

        Debug.Log(name.Length);
        // Trim tabs and extra spaces
        modifiedName = String.Join(" ", name.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries));

        Debug.Log(modifiedName.Length);
        if (modifiedName.Length <= MAX_NAME_LENGTH && Regex.IsMatch(modifiedName, "^[A-Za-z ]+$"))
            isValid = true;
        
        return isValid;
    }
}
