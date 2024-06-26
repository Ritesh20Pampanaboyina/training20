using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Enter details for product " + i + ":");
            Product product = ReadProductDetails(i);
            products.Add(product);
        }

        products.Sort((x, y) => x.Price.CompareTo(y.Price));

        Console.WriteLine("\nSorted Products based on Price:");
        foreach (var product in products)
        {
            Console.WriteLine("Product ID: " + product.ProductId + ", Name: " + product.ProductName + ", Price: " + product.Price.ToString("F2"));
        }

        Console.ReadLine();
    }

    static Product ReadProductDetails(int productId)
    {
        Product product = new Product();
        product.ProductId = productId;

        Console.Write("Enter product name: ");
        product.ProductName = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter price: ");
            if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
            {
                product.Price = price;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid price.");
            }
        }

        return product;
    }
}
