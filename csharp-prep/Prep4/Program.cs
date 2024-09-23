using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input = 1;
        List<int> numList;
        numList = new List<int>();

        for (int i = 0; i < 1000; i++)
        {
            Console.Write("Enter Number:");
            input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                break;
            }
            numList.Add(input);
        }
        int total = 0;
        int length = numList.Count;
        int largest = int.MinValue;
        foreach (int num in numList)
        {
            total += num;
            if (num > largest)
            {
                largest = num;    
            }
        }
        int avg = total/ length;
        Console.WriteLine("The total of the numbers was: " + total);
        Console.WriteLine("The average number was: " + avg);
        Console.WriteLine("The largest number was: " + largest);
        

    }
}