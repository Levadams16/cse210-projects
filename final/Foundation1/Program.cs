using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("JavaScript Basics", "CodeMaster", 600);
        Video video2 = new Video("C# OOP Tutorial", "DevGuru", 900);
        Video video3 = new Video("HTML & CSS Crash Course", "WebWizard", 750);
        Video video4 = new Video("Python for Beginners", "LearnFast", 800);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));
        video1.AddComment(new Comment("Daisy", "Can you make more videos?"));

        // Add comments to video2
        video2.AddComment(new Comment("Eve", "OOP finally makes sense!"));
        video2.AddComment(new Comment("Frank", "Nice examples."));
        video2.AddComment(new Comment("Grace", "This helped my homework."));
        video2.AddComment(new Comment("Hank", "Clear and concise."));

        // Add comments to video3
        video3.AddComment(new Comment("Ivy", "Loved the design tips!"));
        video3.AddComment(new Comment("Jack", "Very beginner friendly."));
        video3.AddComment(new Comment("Karen", "Awesome content."));
        video3.AddComment(new Comment("Leo", "Thanks for sharing!"));

        // Add comments to video4
        video4.AddComment(new Comment("Mia", "Python is so easy now!"));
        video4.AddComment(new Comment("Nate", "Great intro."));
        video4.AddComment(new Comment("Olivia", "Helped me a lot."));
        video4.AddComment(new Comment("Paul", "Looking forward to more."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}