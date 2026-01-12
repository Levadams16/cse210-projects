using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = UserName();

        int userNumber = UserNumber();

        int squareNumber = numberSquared(userNumber);

        int birthYear;
        BirthYear(out birthYear);

        ShowOutput(userName, squareNumber, birthYear);

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string UserName()
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            return name;
        }

        static int UserNumber()
        {
            Console.WriteLine("Please enter your favorite number:");
            
            string fav_str = Console.ReadLine();
            int fav_num = int.Parse(fav_str);

            return fav_num;
        }

        static void BirthYear(out int birthYear)
        {
            Console.WriteLine("Please enter your birth year:");
            birthYear = int.Parse(Console.ReadLine());
        }

        static int numberSquared(int number)
        {
            int squared = number * number;
            return squared;
        }

        static void ShowOutput(string name, int number, int birthYear)
        {
            Console.WriteLine($"{name}, your number squared is {number}.");
            Console.WriteLine($"{name}, you will turn {2026 - birthYear} this year.");
        }
        // Console.WriteLine($"Your favorite number is {fav_num}");


    }
}