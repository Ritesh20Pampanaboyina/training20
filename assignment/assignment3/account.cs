using System;

public class Accounts
{
    private int accountNo;
    private string customerName;
    private string accountType;
    private double balance;

    public Accounts(int accountNo, string customerName, string accountType)
    {
        this.accountNo = accountNo;
        this.customerName = customerName;
        this.accountType = accountType;
        this.balance = 0;
    }

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

    private void Credit(double amount)
    {
        this.balance += amount;
        Console.WriteLine($"Amount {amount} credited. New balance: {balance}");
    }

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
        Accounts account1 = new Accounts(1001, "Ritesh Pampanaboyina", "Savings");
        account1.ShowData();
        account1.UpdateBalance('D', 500);
        account1.UpdateBalance('W', 200);

        account1.ShowData();
    }
}



