CREATE DATABASE JumpForFun;
GO
USE JumpForFun;
GO
CREATE TABLE Trainers (trainerId INT IDENTITY(1, 1) PRIMARY KEY,
								fName NVARCHAR(40) NOT NULL,
								lName NVARCHAR(40) NOT NULL,
								phoneNo CHAR(15) NOT NULL UNIQUE,
								email NVARCHAR(320) NOT NULL UNIQUE,
								creationDate DATE NOT NULL);
CREATE TABLE Bookings (bookingId INT IDENTITY(1, 1) PRIMARY KEY,
								trainerId INT NOT NULL FOREIGN KEY REFERENCES Trainers(trainerId),
								roomId INT NOT NULL UNIQUE,
								creationDate DATE NOT NULL,
								timeStart SMALLDATETIME NOT NULL,
								timeEnd SMALLDATETIME NOT NULL,
								memberCount INT NOT NULL);
CREATE TABLE Members (memberId INT IDENTITY(100000, 1) PRIMARY KEY,
								bookingId INT NULL FOREIGN KEY REFERENCES Bookings(bookingId),
								fName NVARCHAR(40) NOT NULL,
								lName NVARCHAR(40) NOT NULL,
								phoneNo CHAR(15) NOT NULL UNIQUE,
								email NVARCHAR(320) NOT NULL UNIQUE,
								dateOfBirth DATE NOT NULL,
								creationDate DATE NOT NULL);
CREATE TABLE SubscriptionPlan (planId INT PRIMARY KEY,
								subLevel CHAR(20) NOT NULL);
CREATE TABLE Subscription (memberId INT PRIMARY KEY,
								planId INT NOT NULL FOREIGN KEY REFERENCES SubscriptionPlan(planId),
								creationDate DATE NOT NULL,
								expireeDate DATE NOT NULL);
CREATE TABLE Center (id INT IDENTITY(1, 1) PRIMARY KEY,
								memberId INT NULL FOREIGN KEY REFERENCES Members(memberId) UNIQUE,
								trainerId INT NULL FOREIGN KEY REFERENCES Trainers(trainerId) UNIQUE,
								branchLocation NVARCHAR(40) NOT NULL,
								-- Putting a check on making sure that only one column has a value. We shouldn't have someone who is both a member and a trainer,
								-- so one column will be left empty (NULL).
								CHECK((memberId IS NOT NULL AND trainerId IS NULL) OR (memberId IS NULL AND trainerId IS NOT NULL)));

--ALTER TABLE Employees ADD Salary DECIMAL(10, 2);

--INSERT INTO Employees (Name, Position, Salary) VALUES ('John Doe', 'Manager', 37000)
--DELETE FROM Employees WHERE ID=100002;

--SELECT * FROM Employees;

--DROP TABLE Employees;