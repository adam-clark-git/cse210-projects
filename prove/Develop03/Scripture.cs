using System;
using System.Data;
class Scripture {
    private List<Word> _allWords = [];
    private Reference _scripReference;
    private int _wordsToHide = 5;

    public void RandomHideWords()
    {
        int verseSize = _allWords.Count();
        Random randomWordGen = new Random();
        for (int i = 0; i < _wordsToHide; i++)
        {
            for (int randAttempts = 0; randAttempts < 1000; randAttempts++)
            {
                int targetRandomWord = randomWordGen.Next(verseSize);
                if (_allWords[targetRandomWord].CheckBlank() == false)
                {
                    _allWords[targetRandomWord].SetBlank();
                    break;
                }
            }
            
        }
    }

    public void DisplayVerse()
    {
        Console.Clear();
        _scripReference.DisplayReference();
        foreach (Word currentWord in _allWords)
        {
            currentWord.DisplayWord();
        }
        Console.WriteLine();
    }
    public void StoreScripture()
    {
        Console.WriteLine("Input scripture reference");
        string scriptureReference = Console.ReadLine();
        _scripReference = new Reference(scriptureReference);

        Console.WriteLine("Input full verse / verses");
        string verse = Console.ReadLine();
        string[] allWordsString = verse.Split(" ");
        foreach (String word in allWordsString)
        {
            _allWords.Add(new Word(word));
        }
        
    }
    public bool checkAllHidden()
    {
        foreach (Word word in _allWords)
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