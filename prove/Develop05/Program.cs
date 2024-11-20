using System;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        Menu();
    }
    static void Menu()
    {
        GoalManager manager = new GoalManager();
        while (true)
        {
            manager.DisplayPoints();   
            DisplayOptions();
            int userChoice = int.Parse(Console.ReadLine());
            
            if (userChoice == 1)
            {
                manager.InitializeEvent();
            }
            else if (userChoice == 2)
            {
                manager.DisplayGoals();
            }
            else if (userChoice == 3)
            {
                manager.Load();
            }
            else if (userChoice == 4)
            {
                manager.Save();
            }
            else if (userChoice == 5)
            {
                manager.RecordEvents();
            }
            else
            {
                break;
            }
        }
    }
    static void DisplayOptions()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create new goal");
        Console.WriteLine("2. List goals");
        Console.WriteLine("3. Load goals");
        Console.WriteLine("4. Save goals");
        Console.WriteLine("5. Record event");
        Console.WriteLine("6. Quit");
        Console.WriteLine("Select a choice from the menu:");
    }
}