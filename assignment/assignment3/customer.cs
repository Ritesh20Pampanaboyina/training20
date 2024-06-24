using System;

public class Customer
{
    private int customerId;
    private string name;
    private int age;
    private string phone;
    private string city;

    public Customer()
    {
        customerId = 0;
        name = "Unknown";
        age = 0;
        phone = "Unknown";
        city = "Unknown";
    }

    public Customer(int customerId, string name, int age, string phone, string city)
    {
        this.customerId = customerId;
        this.name = name;
        this.age = age;
        this.phone = phone;
        this.city = city;
    }

    public void DisplayCustomer()
    {
        Console.WriteLine($"Customer ID: {customerId}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Phone: {phone}");
        Console.WriteLine($"City: {city}");
    }

    ~Customer()
    {
        Console.WriteLine($"Destructor called for customer {customerId}: {name}");
    }

    public static void DisplayCustomerStatic(Customer customer)
    {
        if (customer != null)
        {
            Console.WriteLine("Static Method: Displaying customer details...");
            customer.DisplayCustomer();
        }
        else
        {
            Console.WriteLine("Static Method: Customer object is null.");
        }
    }
}

class Program
{
    static void Main()
    {
        Customer customer1 = new Customer(1, "Ritesh Pampanaboyina", 22, "9390461995", "Hyderabad");
        customer1.DisplayCustomer();

        Customer customer2 = new Customer();

        Customer.DisplayCustomerStatic(customer1);

        Customer customer3 = new Customer(3, "Roopa, 25, "7841692410", "Vizag");

    }
}