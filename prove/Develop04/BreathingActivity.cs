using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void ExecuteActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);
        }
    }
}