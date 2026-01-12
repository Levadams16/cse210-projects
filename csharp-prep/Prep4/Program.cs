using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();

        int answerNumber = -1;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while (answerNumber != 0)
        {
            string answer = Console.ReadLine();
            
            answerNumber = int.Parse(answer);

            if (answerNumber != 0)
            {
                numberList.Add(answerNumber);
            }
        }

        int sum = 0;

        foreach (int number in numberList)
        {
            sum += number;
        }

        Console.WriteLine($"The sum of the numbers is: {sum}");

        float avg = ((float)sum) / numberList.Count;
        Console.WriteLine($"Your average is: {avg}");

        int max = numberList[0];

        foreach (int number in numberList)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The number that has the highest value is {max}.");
    }
}