using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    public GratitudeActivity()
        : base("Gratitude Activity",
              "This activity will help you focus on gratitude and positivity.")
    {
    }

    protected override void ExecuteActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("\nName something you are grateful for: ");
            Console.ReadLine();
        }
    }
}