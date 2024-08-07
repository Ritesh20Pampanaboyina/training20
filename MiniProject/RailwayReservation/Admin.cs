using System;

public static class Admin
{
    public static void AddTrains()
    {
        Console.Write("Enter Train No: ");
        string trainNo = Console.ReadLine();

        Console.Write("Enter Train Name: ");
        string trainName = Console.ReadLine();

        Console.Write("Enter From Station: ");
        string fromStation = Console.ReadLine();

        Console.Write("Enter To Station: ");
        string toStation = Console.ReadLine();

        Console.Write("Enter Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Price per Seat: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Status: ");
        string status = Console.ReadLine();

        Console.Write("Enter Number of Seats: ");
        int noOfSeats = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Classes: ");
        string classes = Console.ReadLine();

        Trains.AddTrains(trainNo, trainName, fromStation, toStation, date, price, status, noOfSeats, classes);
    }

    public static void UpdateTrains()
    {
        Console.Write("Enter Train ID to update: ");
        int trainID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Train No: ");
        string trainNo = Console.ReadLine();

        Console.Write("Enter Train Name: ");
        string trainName = Console.ReadLine();

        Console.Write("Enter From Station: ");
        string fromStation = Console.ReadLine();

        Console.Write("Enter To Station: ");
        string toStation = Console.ReadLine();

        Console.Write("Enter Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Price per Seat: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Status: ");
        string status = Console.ReadLine();

        Console.Write("Enter Number of Seats: ");
        int noOfSeats = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Classes: ");
        string classes = Console.ReadLine();

        Trains.UpdateTrains(trainID, trainNo, trainName, fromStation, toStation, date, price, status, noOfSeats, classes);
    }
}