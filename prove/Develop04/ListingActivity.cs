using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base("Listing Activity",
              "This activity will help you reflect on the good things in your life.")
    {
    }

    protected override void ExecuteActivity()
    {
        Console.WriteLine($"\n{_prompts[_random.Next(_prompts.Count)]}");
        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}