using System;

public class Saledetails
{
    private int salesNo;
    private int productNo;
    private double price;
    private DateTime dateOfSale;
    private int qty;
    private double totalAmount;

    public Saledetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
    {
        this.salesNo = salesNo;
        this.productNo = productNo;
        this.price = price;
        this.qty = qty;
        this.dateOfSale = dateOfSale;

        Sales();
    }

    public void Sales()
    {
        totalAmount = qty * price;
    }

    public void ShowData()
    {
        Console.WriteLine($"Sales Number: {salesNo}");
        Console.WriteLine($"Product Number: {productNo}");
        Console.WriteLine($"Price per unit: {price:C2}");
        Console.WriteLine($"Quantity: {qty}");
        Console.WriteLine($"Date of Sale: {dateOfSale.ToShortDateString()}");
        Console.WriteLine($"Total Amount: {totalAmount:C2}");
    }
}

class Program
{
    static void Main()
    {
        DateTime dateOfSale = new DateTime(2024, 6, 23); 
        Saledetails sale1 = new Saledetails(1001, 101, 25.50, 5, dateOfSale);

        sale1.ShowData();
    }
}