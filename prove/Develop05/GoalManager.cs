class GoalManager
{
    private int _points = 0;
    private List<Goal> _allGoals = [];
    public void RecordEvents()
    {
        Console.WriteLine("Which event would you like to record?");
        int userChoice = int.Parse(Console.ReadLine())-1;
        _points += _allGoals[userChoice].ProgressEvent();
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
        String fileName = "SavedData.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_points + "");
            foreach (Goal goal in _allGoals)
            {
                outputFile.WriteLine(goal.CompressInfo());
            }
        }
    }
    public void Load()
    {
        String fileName = "SavedData.txt";
        String[] lines = System.IO.File.ReadAllLines(fileName);
        _points = int.Parse(lines[0]); 
        int lineArraySize = lines.Length;
        for (int i = 1; i < lineArraySize; i++)
        {
            string goalType = lines[i].Split(Goal.GetKey())[0];
            if (goalType.Equals("Simple Goal:"))
            {
                _allGoals.Add(new Goal(lines[i]));
            }
            else if (goalType.Equals("Eternal Goal:"))
            {
                _allGoals.Add(new EternalGoal(lines[i]));
            }
            else if (goalType.Equals("Negative Goal:"))
            {
                _allGoals.Add(new NegativeGoal(lines[i]));
            }
            else
            {
                _allGoals.Add(new ChecklistGoal(lines[i]));
            }
        }
    }
    public void InitializeEvent()
    {
        Console.WriteLine("The types of games are:");
        Console.WriteLine("    1. Simple Goal");
        Console.WriteLine("    2. Eternal Goal");
        Console.WriteLine("    3. Checklist Goal");
        Console.WriteLine("    4. Negative Goal");
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
        else if (playerChoice == 4)
        {
            _allGoals.Add(new NegativeGoal());
        }
        else
        {
            _allGoals.Add(new ChecklistGoal());
        }

    }
    public void DisplayPoints()
    {
        Console.WriteLine("You have " + _points + " points. \n");
    }
}