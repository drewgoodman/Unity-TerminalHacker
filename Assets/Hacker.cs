using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // GAME STATE
    int level;
    string password;
    string passwordHint;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
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
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "007")
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
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        if (level == 1)
        {
            Terminal.WriteLine("Log into your Instagram Account!");
            password = "follow";
            passwordHint = "WLOOLF";

        }
        else if (level == 2)
        {
            Terminal.WriteLine("Log into the DMV registry!");
            password = "traffic";
            passwordHint = "FARCFIT";
        }
        else if (level == 3)
        {
            Terminal.WriteLine("Log into your Swiss Bank Account!");
            password = "dividend";
            passwordHint = "IIDNEVDN";
        }
        Terminal.WriteLine("PASSWORD HINT: " + passwordHint);
        Terminal.WriteLine("Please enter your password: ");
    }

    void RunPassword(string input)
    {
        if (input == password) {
            Terminal.WriteLine("That's correct!");
        }
        else
        {
            Terminal.WriteLine("Incorrect, try again. HINT: " + passwordHint);
        }
    }


}
