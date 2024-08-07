--train details
create table Trains (
    TrainID int primary key identity,
    TrainNo varchar(50),
    TrainName varchar(50),
    FromStation varchar(50),
    ToStation varchar(50),
    Date date,
    Price decimal(10, 2),
    Status varchar(10) check (Status in ('Active', 'Inactive')),
    NoOfSeats int,
    Classes varchar(50)
);

sele


insert into Trains (TrainNo, TrainName, FromStation, ToStation, Date, Price, Status, NoOfSeats, Classes) values
('12345', 'Rajdhani Express', 'Delhi', 'Mumbai', '2024-08-10', 1500.00, 'Active', 200, 'Sleeper, AC 3 Tier, AC 2 Tier, AC 1 Tier'),
('67890', 'Shatabdi Express', 'Delhi', 'Agra', '2024-08-12', 800.00, 'Active', 150, 'Executive, AC Chair Car'),
('54321', 'Duronto Express', 'Kolkata', 'Delhi', '2024-08-15', 1200.00, 'Active', 180, 'Sleeper, AC 3 Tier, AC 2 Tier'),
('98765', 'Narmada Express', 'Indore', 'Jabalpur', '2024-08-18', 600.00, 'Inactive', 250, 'Sleeper, General');


create table Users (
    UserID int primary key identity,
    UserName varchar(100),
    Password varchar(100),
    FullName varchar(100),
    Email varchar(100),
    PhoneNumber varchar(15),
    UserRole varchar(50)
);
insert into Users (UserName, Password, FullName, Email, PhoneNumber, UserRole) values
('Ritesh','rrrp2078','Ritesh Pampanaboyina','pritesh2078@gmail.com','9390461995','User'),
('Lokesh','abcd1234','Lokesh Balusu','lokesh@gmail.com','9619766489','User'),
('Tarun','12345678','Tarun Karumanchi','tarun@gmail.com','8996197664','Admin'),
('Sravani','abcdefgh','Sravini Ummidi','sravani@gmail.com','9956193904','Admin'),
('Krishna','1234abcd','Krishna Shetty','krishna@gmail.com','7675894389','User');

create table Booking (
    BookingID INT PRIMARY KEY IDENTITY,
    TrainID INT,
    UserID INT,
    NumberOfSeats INT,
    Status VARCHAR(50),
);
create table CancelBooking (
    CancelBookingID int primary key identity(1,1),
    BookingID int,
    UserID int,
    NumberOfSeats int,
    CancellationDate datetime default getdate(),
);
select * from Trains
select * from Booking
select * from Users

select * from CancelBooking
