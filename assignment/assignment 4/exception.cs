using System;

public class BankAccount
{
    int balance;

    public BankAccount(int initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }
        balance += amount;
        Console.WriteLine("Deposited: " + amount + ". New balance: " + balance);
    }

    public void Withdraw(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }
        if (amount > balance)
        {
            throw new InsufficientBalanceException("Insufficient balance. Cannot withdraw.");
        }
        balance -= amount;
        Console.WriteLine("Withdrawn: " + amount + ". New balance: " + balance);
    }

    public int GetBalance()
    {
        return balance;
    }
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException()
    {
    }

    public InsufficientBalanceException(string message)
        : base(message)
    {
    }

    public InsufficientBalanceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Enter initial balance:");
            int initialBalance = Convert.ToInt32(Console.ReadLine());

            BankAccount account = new BankAccount(initialBalance);

            Console.WriteLine("Enter deposit amount:");
            int depositAmount = Convert.ToInt32(Console.ReadLine());
            account.Deposit(depositAmount);

            Console.WriteLine("Enter withdrawal amount:");
            int withdrawalAmount = Convert.ToInt32(Console.ReadLine());
            account.Withdraw(withdrawalAmount);

            Console.WriteLine("Enter withdrawal amount:");
            withdrawalAmount = Convert.ToInt32(Console.ReadLine());
            account.Withdraw(withdrawalAmount); 

            int balance = account.GetBalance();
            Console.WriteLine("Current balance: " + balance);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Argument exception: " + ex.Message);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Insufficient balance exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General exception occurred: " + ex.Message);
        }
        Console.ReadLine();
    }
}
