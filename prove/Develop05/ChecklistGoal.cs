class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _timesCompleted;
    private int _timesNeededToComplete;
    public override int ProgressEvent()
    {
        if (_completion)
        {
            return 0;
        }
        _timesCompleted += 1;
        if (_timesCompleted < _timesNeededToComplete)
        {
            return _rewardPoints;
        }
        else
        {
            _completion = true;
            return _bonusPoints;
        }
    }
    public override void SetGoalType()
    {
        _goalType = "Checklist Goal:";
    }
    public override string CompressInfo()
    {
        return base.CompressInfo() + KEY + _bonusPoints + KEY + _timesCompleted + KEY + _timesNeededToComplete;
    }
    public override void SetUserGoal()
    {
        base.SetUserGoal();
        Console.WriteLine("How many bonus points should you get when you finish?");
        _bonusPoints = int.Parse(Console.ReadLine());
        Console.WriteLine("How Many Times do you need to complete it?");
        _timesNeededToComplete = int.Parse(Console.ReadLine());
        _timesCompleted = 0;
    }
    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.Write(" -- Currently Completed: " + _timesCompleted + "/" + _timesNeededToComplete);
    }

}