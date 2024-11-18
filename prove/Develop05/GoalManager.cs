class GoalManager
{
    private int _points = 0;
    private List<Goal> _allGoals = [];
    public void RecordEvents()
    {
        Console.WriteLine("Which event would you like to record?");
        int userChoice = int.Parse(Console.ReadLine())-1;
        _points = _allGoals[userChoice].ProgressEvent();
    }
    public void DisplayGoals()
    {
        foreach (Goal goal in _allGoals)
        {
            goal.DisplayGoal();
            Console.WriteLine("");
        }
        
    }
    public void Save()
    {
        string savedText = _points + "\n";
        foreach (Goal goal in _allGoals)
        {
            savedText += goal.CompressInfo() + "\n";
        }
    }
    public void Load()
    {

    }
    public void InitializeEvent()
    {
        Console.WriteLine("The types of games are:");
        Console.WriteLine("    1. Simple Goal");
        Console.WriteLine("    2. Eternal Goal");
        Console.WriteLine("    3. Checklist Goal");
        Console.WriteLine("What type of goal would you like to create?");
        int playerChoice = int.Parse(Console.ReadLine());
        if (playerChoice == 1)
        {
            _allGoals.Add(new Goal());
        }
        else if (playerChoice == 2)
        {
            _allGoals.Add(new EternalGoal());
        }
        else
        {
            _allGoals.Add(new ChecklistGoal());
        }

    }
}