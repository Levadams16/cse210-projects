using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalProgram
{
    public class Journal
    {
        private List<Entry> _entries;
        private List<string> _prompts;
        private Random _random;
        public int CurrentStreak { get; private set; }
        public int LongestStreak { get; private set; }

        public Journal()
        {
            _entries = new List<Entry>();
            _random = new Random();
            CurrentStreak = 0;
            LongestStreak = 0;
            InitializePrompts();
        }

        private void InitializePrompts()
        {
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What made me smile today?",
                "What challenge did I overcome today?",
                "What am I grateful for today?"
            };
        }

        public string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
            CalculateStreak();
        }

        public void CalculateStreak()
        {
            if (_entries.Count == 0)
            {
                CurrentStreak = 0;
                return;
            }

            var sortedEntries = _entries.OrderByDescending(e => DateTime.Parse(e.Date)).ToList();
            
            CurrentStreak = 0;
            int tempStreak = 0;
            DateTime? previousDate = null;

            foreach (var entry in sortedEntries)
            {
                DateTime entryDate = DateTime.Parse(entry.Date).Date;

                if (previousDate == null)
                {
                    DateTime today = DateTime.Now.Date;
                    
                    if (entryDate == today || entryDate == today.AddDays(-1))
                    {
                        tempStreak = 1;
                        previousDate = entryDate;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (entryDate == previousDate.Value.AddDays(-1))
                    {
                        tempStreak++;
                        previousDate = entryDate;
                    }
                    else if (entryDate == previousDate.Value)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            CurrentStreak = tempStreak;

            if (CurrentStreak > LongestStreak)
            {
                LongestStreak = CurrentStreak;
            }
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries in the journal yet.");
                Console.WriteLine();
                return;
            }

            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        writer.WriteLine(entry.ToFileString());
                    }
                }
                Console.WriteLine($"Journal saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"File '{filename}' not found.");
                    return;
                }

                _entries.Clear();
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Entry entry = Entry.FromFileString(line);
                        if (entry != null)
                        {
                            _entries.Add(entry);
                        }
                    }
                }

                CalculateStreak();
                Console.WriteLine($"Journal loaded from {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }

        public void DisplayStreakInfo()
        {
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine($"Current Streak: {CurrentStreak} day(s)");
            Console.WriteLine($"Longest Streak: {LongestStreak} day(s)");
            
            if (CurrentStreak >= 30)
            {
                Console.WriteLine("Amazing! You're on fire! 30+ days!");
            }
            else if (CurrentStreak >= 14)
            {
                Console.WriteLine("Two weeks strong! Keep it up!");
            }
            else if (CurrentStreak >= 7)
            {
                Console.WriteLine("One week streak! You're doing great!");
            }
            else if (CurrentStreak >= 3)
            {
                Console.WriteLine("Nice! Building a habit!");
            }
            else if (CurrentStreak == 0)
            {
                Console.WriteLine("Start your streak today!");
            }
            
            Console.WriteLine("════════════════════════════════════");
        }
    }
}
