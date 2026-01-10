using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your numeric grade (0-100): ");
        int grade = int.Parse(Console.ReadLine());

        string letterGrade;

        if (grade >= 93)
            letterGrade = "A";
        else if (grade >= 90)
            letterGrade = "A-";
        else if (grade >= 87)
            letterGrade = "B+";
        else if (grade >= 83)
            letterGrade = "B";
        else if (grade >= 80)
            letterGrade = "B-";
        else if (grade >= 77)
            letterGrade = "C+";
        else if (grade >= 73)
            letterGrade = "C";
        else if (grade >= 70)
            letterGrade = "C-";
        else if (grade >= 67)
            letterGrade = "D+";
        else if (grade >= 63)
            letterGrade = "D";
        else if (grade >= 60)
            letterGrade = "D-";
        else
            letterGrade = "F";

        Console.WriteLine($"Your letter grade is: {letterGrade}");

        if (grade >= 70)
            Console.WriteLine("Congrats you passed the test!");
        else
            Console.WriteLine("Sorry you failed...");

        if (grade == 67)
            Console.WriteLine("lol 67");
    }
}