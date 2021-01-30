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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
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

    // void Update() {
    //     int index = Random.Range(0, level1Passwords.Length);
    //     print(index);
    //     // PRINT EVERY FRAME TO TEST IN UNITY DEBUG CONSOLE
    // }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Log into your Instagram Account!");
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                passwordHint = "WLOOLF";
                break;
            case 2:
                Terminal.WriteLine("Log into the DMV registry!");
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                passwordHint = "FARCFIT";
                break;
            case 3:
                Terminal.WriteLine("Log into your Swiss Bank Account!");
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                passwordHint = "IIDNEVDN";
                break;
            default:
                Debug.LogError("Invalid level number!!");
                break;
        }
        Terminal.WriteLine("PASSWORD HINT: " + passwordHint);
        Terminal.WriteLine("Please enter your password: ");
    }

    void RunPassword(string input)
    {
        string guess = input.ToLower();
        if (guess == password) {
            Terminal.WriteLine("That's correct!");
        }
        else
        {
            Terminal.WriteLine("Incorrect, try again. HINT: " + passwordHint);
        }
    }

}