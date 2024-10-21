using System;
using System.Data;
class Scripture {
    private List<Word> _AllWords = [];
    private Reference _ScripReference;
    private int _WordsToHide = 5;

    public void RandomHideWords()
    {
        int verseSize = _AllWords.Count();
        Random randomWordGen = new Random();
        for (int i = 0; i < _WordsToHide; i++)
        {
            for (int randAttempts = 0; randAttempts < 1000; randAttempts++)
            {
                int targetRandomWord = randomWordGen.Next(verseSize);
                if (_AllWords[targetRandomWord].CheckBlank() == false)
                {
                    _AllWords[targetRandomWord].SetBlank();
                    break;
                }
            }
            
        }
    }

    public void DisplayVerse()
    {
        Console.Clear();
        _ScripReference.DisplayReference();
        foreach (Word currentWord in _AllWords)
        {
            currentWord.DisplayWord();
        }
        Console.WriteLine();
    }
    public void StoreScripture()
    {
        Console.WriteLine("Input scripture reference");
        string scriptureReference = Console.ReadLine();
        _ScripReference = new Reference(scriptureReference);

        Console.WriteLine("Input full verse / verses");
        string verse = Console.ReadLine();
        string[] allWordsString = verse.Split(" ");
        foreach (String word in allWordsString)
        {
            _AllWords.Add(new Word(word));
        }
        
    }
    public bool checkAllHidden()
    {
        foreach (Word word in _AllWords)
        {
            if (word.CheckBlank() != true)
            {
                return false;
            }
        }
        return true;
    }
    private void test()
    {
        Console.WriteLine("This is a test.");
    }
}