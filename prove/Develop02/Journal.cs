using System;
using System.IO;

class Journal
{
    List<Entry> _AllEntries = new List<Entry>();
    public Journal()
    {

    }
    public void loadEntries()
    {
        Console.WriteLine("Name of File to Load from: ");
        String fileName = Console.ReadLine();
        String[] lines = System.IO.File.ReadAllLines(fileName);
        Entry tempEntry = new Entry();
        bool oddLine = true;
        foreach (String line in lines)
        {
            // Yeah this just dp
            if (oddLine)
            {
                tempEntry.addJournalInput(line);
                oddLine = false;
            }
            else
            {
                tempEntry.addJournalInput("\n" + line);
                _AllEntries.Add(tempEntry);
                tempEntry = new Entry();
                oddLine = true;
            }
            
        }
        

    }
    public void saveEntries()
    {
        Console.WriteLine("Name of File to Save To: ");
        String fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry baseEntry in _AllEntries)
            {
                Console.WriteLine("Saving Line");
                outputFile.WriteLine(baseEntry._JournalInput);
            }
        }

    }
    public void displayEntries()
    {
        foreach (Entry journalEntry in _AllEntries)
        {
            journalEntry.display();
        }
    }
    public void setEntry()
    {
        Entry newEntry = new Entry();
        String combinedInput = newEntry.getDate() + " - ";
        combinedInput += "Prompt: " + newEntry.getPrompt() + " \n";
        combinedInput += newEntry.userInput() + " ";

        newEntry.addJournalInput(combinedInput);
        _AllEntries.Add(newEntry);
    }
}