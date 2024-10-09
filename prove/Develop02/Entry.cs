using System;
using System.Runtime.CompilerServices;
using System.IO;

class Entry
{
    public String _JournalInput = "";
    private List<String> _Prompt = ["How was your day?", "Did you have any violent thoughts?", "Did you encounter any interesting bugs?",
         "What made you want to cry?", "Who are you?"];
    public Entry()
    {
        
    }
    public Entry(String input)
    {
        _JournalInput = input;
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
        int rand = ranGen.Next(0, _Prompt.Count);

        Console.WriteLine(_Prompt[rand]);
        return _Prompt[rand];
    }
    public String userInput()
    {
        return Console.ReadLine();
    }
    public void addJournalInput(String input)
    {
        _JournalInput += input;
    }
    public void display()
    {
        Console.WriteLine(_JournalInput);
    }


}