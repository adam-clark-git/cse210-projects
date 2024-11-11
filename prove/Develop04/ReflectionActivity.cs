class ReflectionActivity : Activity
{
    private List<String> PromptList = [
        "Think of a time when you stood up for someone else.", 
        "Think of a time when you did something really difficult.", 
        "Think of a time when you helped someone in need.", 
        "Think of a time when you did something truly selfless."
    ];
    private List<String> QuestionList = [
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    ];
    public ReflectionActivity(string name, string description) : base(name, description)
    {

    }
    public void StartReflection()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(" --- " + RandPrompt() + " ---");
        Console.WriteLine("Press enter to move on to questions: ");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        Console.WriteLine("You may begin in:");
        CountdownAnimation();
        Console.Clear();
        for (int i = 0; i < GetTimerLength() / 7.2; i++)
        {
            Console.WriteLine(RandQuestion());
            LoadingAnimation();
        }
    }
    public string RandPrompt()
    {
        Random rng = new Random();
        return PromptList[rng.Next(PromptList.Count)];
    }
    public string RandQuestion() {
        Random rng = new Random();
        return QuestionList[rng.Next(QuestionList.Count)];
    }
}