using System;
using System.Threading;

public abstract class Activity
{
    private int _duration;
    private string _name;
    private string _description;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string GetName()
    {
        return _name;
    }

    public void Run()
    {
        DisplayStartingMessage();
        ExecuteActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        try
        {
            Console.Clear();
        }
        catch
        {
            // Ignore if it doesn't work
        }
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);

        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected abstract void ExecuteActivity();
}