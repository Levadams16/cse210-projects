using System;

namespace JournalProgram
{
    public class Entry
    {
        private string _prompt;
        private string _response;
        private string _date;

        public Entry(string prompt, string response, string date)
        {
            _prompt = prompt;
            _response = response;
            _date = date;
        }

        public string GetPrompt()
        {
            return _prompt;
        }

        public string GetResponse()
        {
            return _response;
        }

        public string GetDate()
        {
            return _date;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_prompt}");
            Console.WriteLine($"Response: {_response}");
            Console.WriteLine();
        }

        public string ToFileString()
        {
            return $"{_date}~|~{_prompt}~|~{_response}";
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