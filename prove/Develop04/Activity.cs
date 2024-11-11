using System.Runtime.InteropServices;

class Activity
{
    private string _name;
    private string _description;
    private int _timerLength;
    private const int LOADINGLENGTH = 3;
    protected const int COUNTDOWNLENGTH = 5;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public Activity()
    {
        _name = "Adam";
        _description = "Having a good time";
    }
    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the " + _name + "\n");
        Console.WriteLine(_description + "\n");
        Console.WriteLine("How long, in seconds would you like for this session?");
        _timerLength = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        LoadingAnimation();

    }
    public int GetTimerLength()
    {
        return _timerLength;
    }
    public void EndMessage()
    {
        Console.WriteLine("Well Done!! \n");
        Console.WriteLine("You have completed another " + _timerLength + " seconds of the " + _name + ".");
        LoadingAnimation();
        Console.Clear();
    }
    public void LoadingAnimation()
    {
        int sleepTime = 300;
        for (int i = 0; i < LOADINGLENGTH; i++)
        {
            Console.Write("|");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(sleepTime);
            Console.Write("\b \b");
        }
    }
    public void CountdownAnimation()
    {
        Console.Write(COUNTDOWNLENGTH);
        for (int i = COUNTDOWNLENGTH; i > 0; i--)
        {
            Console.Write("\b \b" + i);
            Thread.Sleep(1000);  
        }
        Console.Write("\b \b");
    }
}