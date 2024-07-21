using System;

class Doctor
{
    public int RegnNo { get; private set; }
    public string Name { get; private set; }
    public decimal FeesCharged { get; private set; }

    public Doctor(int regnNo, string name, decimal feesCharged)
    {
        RegnNo = regnNo;
        Name = name;
        FeesCharged = feesCharged;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Registration Number: " + RegnNo);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Fees Charged: " + FeesCharged);
    }

    public static void Main()
    {
        Console.WriteLine("Enter Registration Number:");
        int regnNo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Doctor's Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Fees Charged:");
        decimal feesCharged = Convert.ToDecimal(Console.ReadLine());

        Doctor doctor = new Doctor(regnNo, name, feesCharged);
        doctor.DisplayDetails();

        Console.ReadLine(); 
    }
}
