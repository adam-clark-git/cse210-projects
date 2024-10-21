
class Word 
{
    private string _Word;
    private string BLANK = "_";
    public Word(string word)
    {
        _Word = word;
    }
    public void SetBlank()
    {
        int wordLength = _Word.Length;
        _Word = "";
        for (int i = 0; i < wordLength; i++)
        {
            _Word += BLANK;
        }
        
    }
    public bool CheckBlank()
    {
        if (_Word.Contains('_'))
        {
            return true;
        }
        return false;
    }
    public void DisplayWord()
    {
        Console.Write(_Word + " ");
    }

}