using System;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "Boise", "ID", "USA");
        Address addr2 = new Address("456 Center Rd", "New York", "NY", "USA");
        Address addr3 = new Address("789 Beach Ave", "Miami", "FL", "USA");

        Lecture lecture = new Lecture(
            "Tech Talk",
            "Learn about new technology",
            "April 10",
            "10:00 AM",
            addr1,
            "Dr. Smith",
            100
        );

        Reception reception = new Reception(
            "Networking Event",
            "Meet professionals",
            "April 12",
            "6:00 PM",
            addr2,
            "rsvp@example.com"
        );

        OutdoorGathering outdoor = new OutdoorGathering(
            "Beach Party",
            "Fun in the sun",
            "April 15",
            "2:00 PM",
            addr3,
            "Sunny with light breeze"
        );

        // Lecture Output
        Console.WriteLine("=================================");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription("Lecture"));

        // Reception Output
        Console.WriteLine("\n=================================");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription("Reception"));

        // Outdoor Output
        Console.WriteLine("\n=================================");
        Console.WriteLine(outdoor.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.GetShortDescription("Outdoor Gathering"));
    }
}