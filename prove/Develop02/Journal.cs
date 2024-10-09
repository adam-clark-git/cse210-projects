using System;
using System.IO;

class Journal
{
    List<Entry> allEntries = new List<Entry>();
    public Journal()
    {

    }
    public void loadEntries()
    {
        Console.WriteLine("Name of File to Load from: ");
        String fileName = Console.ReadLine();
        String[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (String line in lines)
        {
            allEntries.Add(new Entry(line));
        }
        

    }
    public void saveEntries()
    {
        Console.WriteLine("Name of File to Save To: ");
        String fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry baseEntry in allEntries)
            {
                Console.WriteLine("Saving Line");
                outputFile.WriteLine(baseEntry.journalInput);
            }
        }

    }
    public void displayEntries()
    {
        foreach (Entry journalEntry in allEntries)
        {
            journalEntry.display();
        }
    }
    public void setEntry()
    {
        Entry newEntry = new Entry();
        String combinedInput = newEntry.getDate() + " ";
        combinedInput += newEntry.getPrompt() + " ";
        combinedInput += newEntry.userInput() + " ";

        newEntry.setJournalInput(combinedInput);
        allEntries.Add(newEntry);
    }
}