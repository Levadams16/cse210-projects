using System;

namespace JournalProgram
{
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine($"Response: {Response}");
            Console.WriteLine();
        }

        public string ToFileString()
        {
            return $"{Date}~|~{Prompt}~|~{Response}";
        }

        public static Entry FromFileString(string fileString)
        {
            string[] parts = fileString.Split("~|~");
            if (parts.Length == 3)
            {
                return new Entry(parts[1], parts[2], parts[0]);
            }
            return null;
        }
    }
}
