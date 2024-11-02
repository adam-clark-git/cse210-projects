class WritingAssignment : Assignment
{
    string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }
    public void GetWritingInformation()
    {
        GetSummary();
        Console.WriteLine(_title + " by " + GetStudentName());
    }
}