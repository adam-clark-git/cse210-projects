
class Word 
{
    private string _word;
    private string BLANK = "_";
    public Word(string word)
    {
        _word = word;
    }
    public void SetBlank()
    {
        int wordLength = _word.Length;
        _word = "";
        for (int i = 0; i < wordLength; i++)
        {
            _word += BLANK;
        }
        
    }
    public bool CheckBlank()
    {
        if (_word.Contains('_'))
        {
            return true;
        }
        return false;
    }
    public void DisplayWord()
    {
        Console.Write(_word + " ");
    }

}