using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter FirstName:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter LastName:");
        string lastName = Console.ReadLine();

        Display(firstName, lastName);
    }
    public static void Display(string firstName, string lastName)
    {
        string upperFirstName = firstName.ToUpper();
        string upperLastName = lastName.ToUpper();
        Console.WriteLine(upperFirstName);
        Console.WriteLine(upperLastName);
        Console.ReadLine();
    }
}

