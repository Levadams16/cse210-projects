using System;
using System.Collections.Generic;
using System.IO;

/*
For the exceeding requirements this program has a leveling system. 
As the user earns points, their level increases every 1000 points.
The level is displayed along with the score as well.
*/

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        while (true)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine($"Score: {score} | Level: {score / 1000 + 1}");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nGoal Types:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");

                Console.Write("Which type? ");
                string type = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Points: ");
                int points = int.Parse(Console.ReadLine());

                if (type == "1")
                {
                    goals.Add(new SimpleGoal(name, desc, points));
                }
                else if (type == "2")
                {
                    goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "3")
                {
                    Console.Write("Target count: ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("Bonus: ");
                    int bonus = int.Parse(Console.ReadLine());

                    goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                }
            }

            else if (choice == "2")
            {
                Console.WriteLine("\nThe Goals are:");

                if (goals.Count == 0)
                {
                    Console.WriteLine("No goals have been created yet.");
                }
                else
                {
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].GetDetails()} {goals[i].GetProgress()}");
                    }
                }
            }

            else if (choice == "3")
            {
                Console.Write("Filename: ");
                string file = Console.ReadLine();

                using (StreamWriter output = new StreamWriter(file))
                {
                    output.WriteLine(score);

                    foreach (Goal g in goals)
                    {
                        output.WriteLine(g.GetStringRepresentation());
                    }
                }
            }

            else if (choice == "4")
            {
                Console.Write("Filename: ");
                string file = Console.ReadLine();

                string[] lines = File.ReadAllLines(file);

                score = int.Parse(lines[0]);
                goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split("|");

                    if (parts[0] == "SimpleGoal")
                        goals.Add(SimpleGoal.FromString(parts));
                    else if (parts[0] == "EternalGoal")
                        goals.Add(EternalGoal.FromString(parts));
                    else if (parts[0] == "ChecklistGoal")
                        goals.Add(ChecklistGoal.FromString(parts));
                }
            }

            else if (choice == "5")
            {
                Console.WriteLine("\nSelect Goal:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
                }

                int index = int.Parse(Console.ReadLine()) - 1;
                score += goals[index].RecordEvent();
            }

            else if (choice == "6")
            {
                break;
            }
        }
    }
}