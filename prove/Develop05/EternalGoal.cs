class EternalGoal : Goal
{
    public override void SetGoalType()
    {
        _goalType = "Eternal Goal";
    }
    public override int ProgressEvent()
    {
        return _rewardPoints;
    }
}