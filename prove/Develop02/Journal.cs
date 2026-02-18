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
        private int _currentStreak;
        private int _longestStreak;
        private int CompareEntriesByDateDescending(Entry a, Entry b)
        {
            DateTime dateA = DateTime.Parse(a.GetDate());
            DateTime dateB = DateTime.Parse(b.GetDate());

            return dateB.CompareTo(dateA);
        }


        public int GetCurrentStreak()
        {
            return _currentStreak;
        }

        public int GetLongestStreak()
        {
            return _longestStreak;
        }

        public Journal()
        {
            _entries = new List<Entry>();
            _random = new Random();
            _currentStreak = 0;
            _longestStreak = 0;
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
                _currentStreak = 0;
                return;
            }

            _entries.Sort(CompareEntriesByDateDescending);
            List<Entry> sortedEntries = new List<Entry>(_entries);

            
            _currentStreak = 0;
            int tempStreak = 0;
            DateTime? previousDate = null;

            foreach (var entry in sortedEntries)
            {
                DateTime entryDate = DateTime.Parse(entry.GetDate()).Date;

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

            _currentStreak = tempStreak;

            if (_currentStreak > _longestStreak)
            {
                _longestStreak = _currentStreak;
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
            Console.WriteLine($"Current Streak: {_currentStreak} day(s)");
            Console.WriteLine($"Longest Streak: {_longestStreak} day(s)");
            
            if (_currentStreak >= 30)
            {
                Console.WriteLine("Amazing! You're on fire! 30+ days!");
            }
            else if (_currentStreak >= 14)
            {
                Console.WriteLine("Two weeks strong! Keep it up!");
            }
            else if (_currentStreak >= 7)
            {
                Console.WriteLine("One week streak! You're doing great!");
            }
            else if (_currentStreak >= 3)
            {
                Console.WriteLine("Nice! Building a habit!");
            }
            else if (_currentStreak == 0)
            {
                Console.WriteLine("Start your streak today!");
            }
            
            Console.WriteLine("════════════════════════════════════");
        }
    }
}
