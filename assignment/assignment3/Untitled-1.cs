using System;

public class Accounts
{
    private int accountNo;
    private string customerName;
    private string accountType;
    private char transactionType;
    private double amount;
    private double balance;

    // Constructor to initialize account details
    public Accounts(int accountNo, string customerName, string accountType)
    {
        this.accountNo = accountNo;
        this.customerName = customerName;
        this.accountType = accountType;
        this.balance = 0; // Initialize balance to zero initially
    }

    // Function to update balance based on transaction type
    public void UpdateBalance(char transactionType, double amount)
    {
        switch (transactionType)
        {
            case 'D':
                Credit(amount);
                break;
            case 'W':
                Debit(amount);
                break;
            default:
                Console.WriteLine("Invalid transaction type!");
                break;
        }
    }

    // Credit function for deposit
    private void Credit(double amount)
    {
        this.balance += amount;
        Console.WriteLine($"Amount {amount} credited. New balance: {balance}");
    }

    // Debit function for withdrawal
    private void Debit(double amount)
    {
        if (amount <= balance)
        {
            this.balance -= amount;
            Console.WriteLine($"Amount {amount} debited. New balance: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance. Withdrawal not processed.");
        }
    }

    // Method to display account details
    public void ShowData()
    {
        Console.WriteLine($"Account Number: {accountNo}");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Account Type: {accountType}");
        Console.WriteLine($"Current Balance: {balance}");
    }
}

class Program
{
    static void Main()
    {
        // Example usage:
        Accounts account1 = new Accounts(1001, "John Doe", "Savings");
        account1.ShowData(); // Display initial account details

        // Perform transactions
        account1.UpdateBalance('D', 500); // Deposit $500
        account1.UpdateBalance('W', 200); // Withdraw $200

        account1.ShowData(); // Display updated account details
    

