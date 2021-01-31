using UnityEngine;

public class Hacker : MonoBehaviour
{

    // GAME CONFIG DATA

    string[] level1Passwords = {
        "friend", "status", "share", "like", "follow"
    };
    string[] level2Passwords = {
        "season", "traffic", "parallel", "parking", "license", "roadside", "sidewalk"
    };
    string[] level3Passwords = {
        "investment", "dividend", "retirement", "insurance", "interest", "compound"
    };

    // GAME STATE
    int level;
    string password;
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
        else if (currentScreen == Screen.Win)
        {
            ShowMainMenu();
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Invalid input, try again.");
        }
    }

    void DisplayHint()
    {
        Terminal.WriteLine("HINT: " + password.Anagram().ToUpper());
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        DisplayChallenge();
        Terminal.WriteLine("Enter your password.");
        DisplayHint();
    }

    void DisplayChallenge()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Log into your Instagram Account!");
                password = CreateRandomPassword(level1Passwords);
                break;
            case 2:
                Terminal.WriteLine("Log into the DMV registry!");
                password = CreateRandomPassword(level2Passwords);
                break;
            case 3:
                Terminal.WriteLine("Log into your Swiss Bank Account!");
                password = CreateRandomPassword(level3Passwords);
                break;
            default:
                Debug.LogError("Invalid level number!!");
                break;
        }
    }

    string CreateRandomPassword(string[] passwordBank)
    {
        int index = Random.Range(0, passwordBank.Length);
        return passwordBank[index];
    }

    void RunPassword(string input)
    {
        string guess = input.ToLower();
        if (guess == password) {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect, try again.");
            DisplayHint();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("That's correct!");
                break;
            case 2:
                Terminal.WriteLine("Good job!");
                break;
            case 3:
                Terminal.WriteLine("Outstanding work!");
                break;
            default:
                break;
        }
        Terminal.WriteLine("Press ENTER to return to menu.");
    }

}