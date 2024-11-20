class NegativeGoal : Goal
{
    public NegativeGoal(string textLine) : base(textLine)
    {

    }
    public NegativeGoal() : base()
    {

    }
    public override void SetGoalType()
    {
        _goalType = "Negative Goal:";
    }
    public override int ProgressEvent()
    {
        return 0 - _rewardPoints;
    }
    public override void SetUserGoal()
    {
        Console.WriteLine("What is the name of this goal?");
        _name = Console.ReadLine();
        Console.WriteLine("What is the description of this goal?");
        _description = Console.ReadLine();
        Console.WriteLine("How many negative points is this worth?");
        _rewardPoints = int.Parse(Console.ReadLine());
        _completion = false;
    }
}