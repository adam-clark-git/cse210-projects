class Assignment
{
    private string _studentName;
    private string _topic;
    public Assignment()
    {
        _topic = "sampleTopic";
        _studentName = "sampleName";
    }
    public Assignment(string studentName, string topic)
    {
        _topic = topic;
        _studentName = studentName;
    }
    public void GetSummary()
    {
        Console.WriteLine(_studentName + " - " + _topic);

    }
    protected string GetStudentName()
    {
        return _studentName;
    }







}