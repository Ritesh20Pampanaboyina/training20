using System;

public interface IStudent
{
    int StudentId { get; set; }
    string Name { get; set; }

    void ShowDetails();
}

public class Dayscholar : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Dayscholar Details:");
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Type: Dayscholar");
        Console.WriteLine();
    }
}

public class Resident : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Resident Details:");
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Type: Resident");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Dayscholar dayscholar = new Dayscholar { StudentId = 1035492, Name = "Ritesh Pampanaboyina" };
        Resident resident = new Resident { StudentId = 1035493, Name = "Roopa Pampanaboyina" };

        dayscholar.ShowDetails();
        resident.ShowDetails();
    }
}