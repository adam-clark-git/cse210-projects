using System;
using System.ComponentModel.DataAnnotations;
/*
For this assignment, write a C# program that has several simple functions:

    DisplayWelcome - Displays the message, "Welcome to the Program!"
    PromptUserName - Asks for and returns the user's name (as a string)
    PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
    DisplayResult - Accepts the user's name and the squared number and displays them.

Your Main function should then call each of these functions saving the return values and passing data to them as necessary.

Sample output of the program could look as follows:


Welcome to the program!
Please enter your name: Brother Burton
Please enter your favorite number: 42
Brother Burton, the square of your number is 1764
*/
class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        String name = PromptUserName();
        int num = PromptUserNumber();
        int sqrNum = SquareNumber(num);
        DisplayResult(name, sqrNum);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static String PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int num)
    {
        return num * num;
    }
    static void DisplayResult(String name, int sqrNum)
    {
        Console.WriteLine(name + ", the square of your number is " + sqrNum);
    }
}