using System;
using System.Runtime.CompilerServices;
using System.IO;

class Entry
{
    public String journalInput = "";
    private List<String> Prompt = ["How was your day?", "Did you have any violent thoughts?", "Did you encounter any interesting bugs?",
         "What made you want to cry?", "Who are you?"];
    public Entry()
    {
        
    }
    public Entry(String input)
    {
        journalInput = input;
    }
    public String getDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }
    public String getPrompt()
    {
        Random ranGen = new Random();
        int rand = ranGen.Next(0, Prompt.Count);

        Console.WriteLine(Prompt[rand]);
        return Prompt[rand];
    }
    public String userInput()
    {
        return Console.ReadLine();
    }
    public void setJournalInput(String input)
    {
        journalInput = input;
    }
    public void display()
    {
        Console.WriteLine(journalInput);
    }


}