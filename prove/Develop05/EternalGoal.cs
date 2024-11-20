class EternalGoal : Goal
{
    public EternalGoal(string textLine) : base(textLine)
    {

    }
    public EternalGoal() : base()
    {

    }
    public override void SetGoalType()
    {
        _goalType = "Eternal Goal:";
    }
    public override int ProgressEvent()
    {
        return _rewardPoints;
    }
}