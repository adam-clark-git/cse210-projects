using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int tryAgain = 0;
        do
        {
            int x = 1;
            Random ranGen = new Random();
            int magicNum = ranGen.Next(1,101);
            Console.WriteLine("What's the magic number? " + magicNum);

            do
            {
                Console.WriteLine("What is your guess?");
                int guess = int.Parse(Console.ReadLine());
                
                if (guess == magicNum)
                {
                    Console.WriteLine($"You got it in {x}!");
                    break;
                }
                else if (guess < magicNum)
                {
                    Console.WriteLine("Under");
                }
                else
                {
                    Console.WriteLine("Over");
                }
                x++;
            } while( x < 1000);
            Console.WriteLine("Would you like to try again? (Press 1 to do so)");
            tryAgain = int.Parse(Console.ReadLine());
        } while (tryAgain == 1);
    }
}