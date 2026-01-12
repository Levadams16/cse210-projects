using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?");
        int magic = int.Parse(Console.ReadLine());
        int guess = -1;

        while (magic != guess)
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            if (guess == magic)
                Console.WriteLine("You guessed correctly!");

            else if (guess < magic)
                Console.WriteLine("Higher");
            else if (guess > magic)
                Console.WriteLine("Lower");
        }
    }
}