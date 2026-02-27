using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity()
        : base("Reflection Activity",
              "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    protected override void ExecuteActivity()
    {
        Console.WriteLine($"\n{_prompts[_random.Next(_prompts.Count)]}");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n{_questions[_random.Next(_questions.Count)]}");
            ShowSpinner(4);
        }
    }
}