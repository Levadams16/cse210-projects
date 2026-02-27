using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        List<string> sessionLog = new List<string>();
        bool running = true;

        while (running)
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                // Ignore if it doesn't work
            }
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity (Extra)");
            Console.WriteLine("5. View Session Log");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    try
                    {
                        Console.Clear();
                    }
                    catch
                    {
                        // Ignore if it doesn't work
                    }
                    Console.WriteLine("Session Log:");
                    foreach (var log in sessionLog)
                        Console.WriteLine(log);
                    Console.WriteLine("\nPress Enter to return...");
                    Console.ReadLine();
                    continue;
                case "6":
                    running = false;
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
                sessionLog.Add($"{activity.GetName()} completed for {activity.GetDuration()} seconds.");
            }
        }
    }
}

/*
EXCEEDING REQUIREMENTS:
- Added GratitudeActivity
*/