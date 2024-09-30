using System;
using System.Security.AccessControl;


public class Job
{
    public String _company;
    public String _title;
    public int _startYear;
    public int _endYear;

    public Job(String company, String title, int startYear, int endYear)
    {
        _company = company;
        _title = title;
        _startYear = startYear;
        _endYear = endYear;
    }
    public Job()
    {
        _company = "";
        _title = "";
        _startYear = 0;
        _endYear = 0;
    }    
    public void JobDetails()
    {
        Console.WriteLine(_title + " (" + _company + ") " + _startYear + "-" + _endYear);
    }


}



