
using System;
using System.Data.SqlClient;

public static class Users
{
    public static void BookTickets()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        int userID = Trains.GetUserID(username, password);
        if (userID == 0)
        {
            Console.WriteLine("User not found. Please provide additional details to register:");

            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();

            Trains.AddUser(username, password, fullName, email, phoneNumber, "User");
            userID = Trains.GetUserID(username, password);

            Console.WriteLine("User registered successfully.");
        }
        Trains.ListTrains();

        Console.Write("Enter TrainID to book tickets: ");
        int trainID = Convert.ToInt32(Console.ReadLine());

        var trainDetails = Trains.GetTrainDetails(trainID);
        if (trainDetails.Status == "Inactive")
        {
            Console.WriteLine("Cannot book tickets for Inactive trains");
            return;
        }

        Console.Write("Enter number of seats to book (max 5): ");
        int seats = Convert.ToInt32(Console.ReadLine());

        if (seats > 5)
        {
            Console.WriteLine("Cannot book more than 5 tickets at a time.");
            return;
        }

        int availableSeats = Trains.GetAvailableSeats(trainID);

        if (availableSeats < seats)
        {
            Console.WriteLine("Not enough seats available.");
            return;
        }

        Trains.ConfirmBooking(trainID, userID, seats);
        Trains.UpdateSeatAvailability(trainID, seats);

        int bookingID = Trains.GetLatestBookingID(userID, trainID);
        var userDetails = Trains.GetUserDetails(userID);
        var bookingDetails = Trains.GetBookingDetails(bookingID);

        PrintTicket(bookingID, userDetails, trainDetails, bookingDetails);

        Console.WriteLine("Booking confirmed!");
    }

    public static void CancelTickets()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        int userID = Trains.GetUserID(username, password);

        if (userID == 0)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.Write("Enter BookingID to cancel: ");
        int bookingID = Convert.ToInt32(Console.ReadLine());

        using (var conn = Trains.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand("SELECT TrainID, NumberOfSeats FROM Booking WHERE BookingID = @BookingID AND Status = 'Confirmed' AND UserID = @UserID", conn))
            {
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                cmd.Parameters.AddWithValue("@UserID", userID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("Booking not found or already cancelled.");
                        return;
                    }

                    int trainID = (int)reader["TrainID"];
                    int bookedSeats = (int)reader["NumberOfSeats"];
                    reader.Close();

                    Console.Write("Enter number of seats to cancel: ");
                    int seatsToCancel = Convert.ToInt32(Console.ReadLine());

                    if (seatsToCancel <= 0 || seatsToCancel > bookedSeats)
                    {
                        Console.WriteLine("Invalid number of seats.");
                        return;
                    }

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var updateBookingCmd = new SqlCommand("UPDATE Booking SET NumberOfSeats = NumberOfSeats - @SeatsToCancel WHERE BookingID = @BookingID AND UserID = @UserID", conn, transaction))
                            {
                                updateBookingCmd.Parameters.AddWithValue("@SeatsToCancel", seatsToCancel);
                                updateBookingCmd.Parameters.AddWithValue("@BookingID", bookingID);
                                updateBookingCmd.Parameters.AddWithValue("@UserID", userID);
                                int rowsAffected = updateBookingCmd.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Failed to update booking.");
                                }

                                using (var updateSeatsCmd = new SqlCommand("UPDATE Trains SET NoOfSeats = NoOfSeats + @SeatsToCancel WHERE TrainID = @TrainID", conn, transaction))
                                {
                                    updateSeatsCmd.Parameters.AddWithValue("@SeatsToCancel", seatsToCancel);
                                    updateSeatsCmd.Parameters.AddWithValue("@TrainID", trainID);
                                    updateSeatsCmd.ExecuteNonQuery();
                                }

                                using (var insertCancelBookingCmd = new SqlCommand("INSERT INTO CancelBooking (BookingID, UserID, NumberOfSeats) VALUES (@BookingID, @UserID, @SeatsToCancel)", conn, transaction))
                                {
                                    insertCancelBookingCmd.Parameters.AddWithValue("@BookingID", bookingID);
                                    insertCancelBookingCmd.Parameters.AddWithValue("@UserID", userID);
                                    insertCancelBookingCmd.Parameters.AddWithValue("@SeatsToCancel", seatsToCancel);
                                    insertCancelBookingCmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                Console.WriteLine("Partial cancellation successful.");
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
        }
    }

    private static void PrintTicket(int bookingID, (string FullName, string Email, string PhoneNumber) userDetails, (string TrainNo, string TrainName, string FromStation, string ToStation, DateTime Date, decimal Price, string Status) trainDetails, (int TrainID, int NumberOfSeats, string Status) bookingDetails)
    {
        Console.WriteLine("\n--- Ticket ---");
        Console.WriteLine($"BookingID: {bookingID}");
        Console.WriteLine($"Name: {userDetails.FullName}");
        Console.WriteLine($"Email: {userDetails.Email}");
        Console.WriteLine($"Phone: {userDetails.PhoneNumber}");
        Console.WriteLine($"Train No: {trainDetails.TrainNo}");
        Console.WriteLine($"Train Name: {trainDetails.TrainName}");
        Console.WriteLine($"From: {trainDetails.FromStation}");
        Console.WriteLine($"To: {trainDetails.ToStation}");
        Console.WriteLine($"Date: {trainDetails.Date}");
        Console.WriteLine($"Price per Seat: {trainDetails.Price:C}");
        Console.WriteLine($"Number of Seats: {bookingDetails.NumberOfSeats}");
        Console.WriteLine($"Total Price: {trainDetails.Price * bookingDetails.NumberOfSeats:C}");
        Console.WriteLine($"Status: {bookingDetails.Status}");
        Console.WriteLine("---------------");
    }
}
