using System;

class Program
{
    static void Main(string[] args)
    {
        runMenu();
    }
    static void runMenu()
    {
        Journal journal = new Journal();
        String input = "";
        for (int i = 0; i < 5000; i++)
        {
            showMenu();
            input = Console.ReadLine();
            if (input.Equals("1"))
            {
                journal.setEntry();
            }
            else if (input.Equals("2"))
            {
                journal.displayEntries();
            }
            else if (input.Equals("3"))
            {
                journal.loadEntries();
            }
            else if (input.Equals("4"))
            {
                journal.saveEntries();
            }
            else {
                break;
            }
        }
    }
    static void showMenu()
    {
        Console.WriteLine("Please select one of the following options");
        Console.WriteLine("1) Write");
        Console.WriteLine("2) Display");
        Console.WriteLine("3) Load");
        Console.WriteLine("4) Save");
        Console.WriteLine("5) Quit");
        Console.WriteLine("What would you like to do?");
    }
}