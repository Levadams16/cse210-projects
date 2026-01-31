using System;
using System.IO;

namespace JournalProgram
{
    class Program
    {
        // I made a streak counter for exceeding requirements
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine();

            string defaultFile = "myjournal.txt";
            if (File.Exists(defaultFile))
            {
                journal.LoadFromFile(defaultFile);
                Console.WriteLine();
            }

            journal.DisplayStreakInfo();
            Console.WriteLine();

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal);
                        break;
                    case "2":
                        DisplayJournal(journal);
                        break;
                    case "3":
                        SaveJournal(journal);
                        break;
                    case "4":
                        LoadJournal(journal);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye! Keep up the journaling!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (running)
                {
                    journal.DisplayStreakInfo();
                    Console.WriteLine();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
        }

        static void WriteNewEntry(Journal journal)
        {
            string prompt = journal.GetRandomPrompt();
            Console.WriteLine(prompt);
            Console.Write("> ");
            string response = Console.ReadLine();

            string date = DateTime.Now.ToShortDateString();
            
            int previousStreak = journal.CurrentStreak;
            Entry newEntry = new Entry(prompt, response, date);
            journal.AddEntry(newEntry);

            Console.WriteLine("Entry added successfully!");
            
            if (journal.CurrentStreak > previousStreak)
            {
                Console.WriteLine($"Streak increased to {journal.CurrentStreak} day(s)!");
            }
            
            Console.WriteLine();
        }

        static void DisplayJournal(Journal journal)
        {
            Console.WriteLine();
            journal.DisplayAll();
        }

        static void SaveJournal(Journal journal)
        {
            Console.Write("What is the filename? ");
            string filename = Console.ReadLine();
            journal.SaveToFile(filename);
            Console.WriteLine();
        }

        static void LoadJournal(Journal journal)
        {
            Console.Write("What is the filename? ");
            string filename = Console.ReadLine();
            journal.LoadFromFile(filename);
            Console.WriteLine();
        }
    }
}