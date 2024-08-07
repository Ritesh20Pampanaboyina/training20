
using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Railway Reservation System");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        int userID = Trains.GetUserID(username, password);
        string userRole = userID == 0 ? "Guest" : GetUserRole(userID);

        if (userRole == "Guest")
        {
            Console.WriteLine("Invalid credentials.");
            return;
        }

        Console.WriteLine($"Logged in as {userRole}");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. List All Trains");

            if (userRole == "Admin")
            {
                Console.WriteLine("2. Add Train");
                Console.WriteLine("3. Update Train");
                Console.WriteLine("4. Exit");
            }
            else if (userRole == "User")
            {
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4. Exit");
            }

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Trains.ListTrains();
                    break;

                case 2:
                    if (userRole == "Admin")
                    {
                        Admin.AddTrains();
                    }
                    else if (userRole == "User")
                    {
                        Users.BookTickets();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                    break;

                case 3:
                    if (userRole == "Admin")
                    {
                        Admin.UpdateTrains();
                    }
                    else if (userRole == "User")
                    {
                        Users.CancelTickets();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                    break;

                case 4:
                    if (userRole == "Admin" || userRole == "User")
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static string GetUserRole(int userID)
    {
        using (var conn = Trains.GetConnection())
        {
            conn.Open();
            using (var cmd = new SqlCommand("SELECT UserRole FROM Users WHERE UserID = @UserID", conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                return cmd.ExecuteScalar()?.ToString() ?? "Guest";
            }
        }
    }
}
