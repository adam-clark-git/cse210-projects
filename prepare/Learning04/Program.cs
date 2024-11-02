using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        Assignment a = new Assignment();
        a.GetSummary();
        MathAssignment b = new MathAssignment("Brion", "Algebra", "27", "8-50");
        b.GetHomeworkList();
        WritingAssignment c = new WritingAssignment("Adam", "My Love Life", "Why I'm doing A-Okay");
        c.GetWritingInformation();
    }
}