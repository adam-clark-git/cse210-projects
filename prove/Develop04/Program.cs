using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
        bool continueRunning = true;
        while(continueRunning)
        {
            continueRunning = Menu();
        }
    }
    static bool Menu()
    {
        DisplayMenu();
        string input = Console.ReadLine();
        if (input.Equals("4"))
        {
            Console.Clear();
            return false;
        }
        else if (input.Equals("1"))
        {
            string name = "Breathing Activity";
            string description = "This activity will help you relax by guiding through your breathing slowly. Clear your mind and focus on breathing.";
            BreathingActivity currentActivity = new BreathingActivity(name, description);
            currentActivity.StartMessage();
            currentActivity.StartBreathing();
            currentActivity.EndMessage();
        }
        else if (input.Equals("2"))
        {
            string name = "Reflecting Activity";
            string description = "This activity will help you reflect on the times in your life when you have shown strength and resilience. This will help you recognize the power you have and help you use it in other places.";
            ReflectionActivity currentActivity = new ReflectionActivity(name, description);
            currentActivity.StartMessage();
            currentActivity.StartReflection();
            currentActivity.EndMessage();
        }
        else if (input.Equals("3"))
        {
            string name = "Listing Activity";
            string description = "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area";
            ListingActivity currentActivity = new ListingActivity(name, description);
            currentActivity.StartMessage();
            currentActivity.StartListing();
            currentActivity.EndMessage();
        }
        return true;
    }
    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options");
        Console.WriteLine("   1. Start breathing activity");
        Console.WriteLine("   2. Start reflecting activity");
        Console.WriteLine("   3. Start listing activity");
        Console.WriteLine("   4. Quit");
        Console.WriteLine("Select a choice from the menu:");
    }
}