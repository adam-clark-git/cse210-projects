using System;

class Program
{
    static void Main(string[] args)
    {
        string fName = "";
        string lName = "";

        Console.WriteLine("What is your first name?");
        fName = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        lName = Console.ReadLine();
        
        Console.WriteLine($"Your name is {lName}, {fName} {lName}");
        
    }
}