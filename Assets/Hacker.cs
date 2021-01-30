using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal Hacker.\n\nWhat would you like to hack today?\n");
        Terminal.WriteLine("1. Hack an Instagram account");
        Terminal.WriteLine("2. Hack the DMV");
        Terminal.WriteLine("3. Hack a bank");
        Terminal.WriteLine("///////////////////////");
        Terminal.WriteLine("Please input a number: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "1")
        {
            print("You chose level #1");
        }
        else if (input == "2")
        {
            print("You chose level #2");
        }
        else if (input == "3")
        {
            print("You chose level #3");
        }
        else
        {
            Terminal.WriteLine("Invalid input, try again.");
        }
    }


}
