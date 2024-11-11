class BreathingActivity : Activity
{
    private int _breathingTime;
    public BreathingActivity(string name, string description) : base(name, description)
    {
        _breathingTime = COUNTDOWNLENGTH *2;
    }
    public void StartBreathing()
    {
        for (int i = 0; i < GetTimerLength()/ _breathingTime; i++)
        {
            Console.Write("Breathe in...");
            CountdownAnimation();
            Console.WriteLine("");
            Console.Write("Now Breathe out...");
            CountdownAnimation();
            Console.WriteLine("\b");
        }
    }
}