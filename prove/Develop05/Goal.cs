using System.Numerics;

class Goal
{
    protected string _name;
    protected string _description;
    protected int _rewardPoints;
    protected string _goalType;
    protected bool _completion;
    protected string KEY = "*";
    public Goal(string textLine)
    {
        SetGoalType();

    }
    public Goal() {
        SetUserGoal();
        SetGoalType();
    }
    public virtual int ProgressEvent()
    {
        if (_completion) {
            return 0;
        }
        _completion = true;
        return _rewardPoints;
    }
    public virtual void SetUserGoal()
    {
        Console.WriteLine("What is the name of this goal?");
        _name = Console.ReadLine();
        Console.WriteLine("What is the description of this goal?");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is this worth?");
        _rewardPoints = int.Parse(Console.ReadLine());
        _completion = false;
    }
    public virtual void SetGoalType()
    {
        _goalType = "Simple Goal:";
    }
    public virtual string CompressInfo()
    {
        return _goalType + KEY + _name + KEY + _description + KEY + _rewardPoints + KEY + _completion;
    }
    public virtual void DisplayGoal()
    {
        string completionIcon = " ";
        if (_completion)
        {
            completionIcon = "*";
        }
        Console.Write(" [" + completionIcon + "] " + _name + " (" + _description + ")");
    }

}