using System;
public class Resume
{
    public String _name;
    public List<Job> _jobList;
    public Resume(String name, List<Job> jobList)
    {
        _name = name;
        _jobList = jobList;
    }
    public void Display()
    {
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Jobs: ");
        foreach (Job j in _jobList)
        {
            j.JobDetails();
        }




    }










}