using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    //Game configuration data (Start)
    const string menuHint = "Type main menu to access the menu";
    string[] passwordLevel1 = {"Books", "History", "National Treasure", "Isles", "Silence"};
    string[] passwordLevel2 = { "Legal Guns", "Heros", "Castle", "Buick 8", "Resident evil 2" };
    string[] passwordLevel3 = { "Apollo 13", "Tom Hanks", "Space Ship", "Rocket", "Stars" };
    string password;
    //Game configuration data (End)

    //Game States/Modes (Start)
    // Game state i.e which level it is in
    int level;
    //Which mode we are in 
	enum Screen {MainMenu, Password, WinScreen};
	Screen currentState;
    //Game States/Modes (End)
    // Use this for initialization
    void Start () {
		string greeting = "Greetings Reaper";
		ShowMainMenu(greeting);
	}
	void ShowMainMenu(string greet){
        currentState = Screen.MainMenu;
        Terminal.ClearScreen();

		Terminal.WriteLine(greet);
		Terminal.WriteLine("Hack these places in order to get info about the syndicate");

		Terminal.WriteLine("");

		Terminal.WriteLine("Press 1 for The State Library");
		Terminal.WriteLine("Press 2 for The LasVegas Police Station");
		Terminal.WriteLine("Press 3 for NASA");

		Terminal.WriteLine("Enter Your Selection : ");
	}
	
	void OnUserInput(string input){
		if(input == "main menu")
		{
			ShowMainMenu("");
		}
		else if(currentState == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
        else if(currentState == Screen.Password)
        {
            CheckForPasswords(input);
        }
	}

	void RunMainMenu(string input){
		if(input == "1")
		{
			level = 1;
        // for random generation of random numbers we do Random.Range(min, max)
        // min is included max not
        //finding length of an array and or strings string/string var/array.Length()
			AskForPassword();
		}

		else if(input == "2")
		{
			level = 2;
            AskForPassword();
		}

		else if(input == "3")
		{
			level = 3;
            AskForPassword();
		}

		else if(input == "007")
		{
			Terminal.WriteLine("Please Choose A Valid Level Mr Bond: ");
        }

		else
		{
			Terminal.WriteLine("Plese Choose a Valid level: ");
        }
	}

    void SetPassword()
    {
        if(level == 1) 
        {
            password = passwordLevel1[Random.Range(0, passwordLevel1.Length)];
        }
        else if(level == 2)
        {
            password = passwordLevel2[Random.Range(0, passwordLevel2.Length)];
        }
        else if(level == 3)
        {
            password = passwordLevel3[Random.Range(0, passwordLevel3.Length)];
        }
    }

	void AskForPassword(){
		currentState = Screen.Password;
        SetPassword();
		Terminal.ClearScreen();

        Terminal.WriteLine(menuHint);
		Terminal.WriteLine("Enter your Password: " + password.Anagram());
	}

    void CheckForPasswords(string input)
    {
        if(input == password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        currentState = Screen.WinScreen;
        if (level == 1)
        {
            Terminal.WriteLine("Have a Book.....");
            Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
           ");
        }
        else if (level == 2)
        {
            Terminal.WriteLine("Here's a gun!");
            Terminal.WriteLine(@"	
  /-\______________
  |                |
  \-----------------
   /    /)  /
  /    /----
 /    /
/____/ 
"
          );

        }
        else if (level == 3)
        {
            Terminal.WriteLine(@"


  /\
 /||\
/:||:\
|:||:|
|/||\|
  **
BLAST OFF 

"
);
        }

        
        Terminal.WriteLine(menuHint + " for a better challenge!");

    }

	// Update is called once per frame
	void Update () {
	}
}
