using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // GAME STATE
    int level;

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
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr. Bond.");
        }
        else if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid input, try again.");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("You have chosen level " + level);
    }


}
