using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture myScripture = new Scripture();
        myScripture.StoreScripture();
        string exit = "";
        bool allHidden = false;
        while (!exit.Equals("quit") && !allHidden)
        {
            myScripture.DisplayVerse();
            Console.WriteLine("type \"exit\" to quit");
            exit = Console.ReadLine();
            allHidden = myScripture.checkAllHidden();
            myScripture.RandomHideWords();
        }
        Console.WriteLine("end");
    }
}