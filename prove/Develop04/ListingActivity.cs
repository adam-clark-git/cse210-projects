class ListingActivity : Activity
{
    private List<String> prompts = [
        "Who are people that you appreciate?", 
        "What are personal strengths of yours?", 
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];
    public ListingActivity(string name, string description) : base(name,description)
    {

    }
    public void StartListing()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine(" --- " + RandPrompt() + " ---");
        Console.Write("You may begin in: ");
        CountdownAnimation();
        Console.WriteLine("");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetTimerLength());
        int numResponses = 0;
        while (true)
        {
            Console.ReadLine();
            numResponses++;
            DateTime currentTime = DateTime.Now;
            if (currentTime > endTime)
            {
                break;
            }
        }
        Console.WriteLine("You listed " +  numResponses + " items!");
    }
    public string RandPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}