using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Grade:");
        String input = Console.ReadLine();

        int num = int.Parse(input);
        int sign = (num % 10);
        String signResult = "";
        String result = "";

        if (sign >= 7) 
        {
            signResult = "+";
        }
        else if (sign < 3)
        {
            signResult = "-";
        }


        if (num >= 90)
        {
            if (signResult.Equals("+"))
            {
                result = "n A";
            }
            else
            {
                result = $"n A{signResult}";
            }
           
        }
        else if (num >= 80)
        {
            result = $" B{signResult}";
        }
        else if (num >= 70)
        {
            result = $" C{signResult}";
        }
        else if (num >= 60)
        {
            result = $" D{signResult}";
        }
        else {
            result = $" F";
        }
        Console.WriteLine($"You got a{result}.");
        if (num >= 70)
        {
            Console.WriteLine("You Passed!");
        }
        else
        {
            Console.WriteLine("Better Luck Next Time. :(");
        }
    }
}