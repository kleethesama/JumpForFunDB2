CREATE DATABASE JumpForFun;
GO
USE JumpForFun;
GO
SET DATEFORMAT dmy;  
GO  
CREATE TABLE Trainers (TrainerId INT IDENTITY(1, 1) PRIMARY KEY,
								FName NVARCHAR(40) NOT NULL,
								LName NVARCHAR(40) NOT NULL,
								PhoneNo CHAR(15) NOT NULL UNIQUE,
								Email NVARCHAR(320) NOT NULL UNIQUE,
								CreationDate DATE NOT NULL);
CREATE TABLE Bookings (BookingId INT IDENTITY(1, 1) PRIMARY KEY,
								TrainerId INT NOT NULL FOREIGN KEY REFERENCES Trainers(TrainerId),
								RoomId INT NOT NULL UNIQUE,
								CreationDate DATE NOT NULL,
								TimeStart SMALLDATETIME NOT NULL,
								TimeEnd SMALLDATETIME NOT NULL,
								MemberCount INT NOT NULL);
CREATE TABLE Members (MemberId INT IDENTITY(100000, 1) PRIMARY KEY,
								BookingId INT NULL FOREIGN KEY REFERENCES Bookings(BookingId),
								FName NVARCHAR(40) NOT NULL,
								LName NVARCHAR(40) NOT NULL,
								PhoneNo CHAR(15) NOT NULL UNIQUE,
								Email NVARCHAR(320) NOT NULL UNIQUE,
								DateOfBirth DATE NOT NULL,
								CreationDate DATE NOT NULL);
CREATE TABLE SubscriptionPlan (PlanId INT PRIMARY KEY,
								SubLevel CHAR(20) NOT NULL);
CREATE TABLE Subscription (MemberId INT PRIMARY KEY,
								PlanId INT NOT NULL FOREIGN KEY REFERENCES SubscriptionPlan(PlanId),
								CreationDate DATE NOT NULL,
								ExpireeDate DATE NOT NULL);
CREATE TABLE Center (Id INT IDENTITY(1, 1) PRIMARY KEY,
								MemberId INT NULL FOREIGN KEY REFERENCES Members(MemberId) UNIQUE,
								TrainerId INT NULL FOREIGN KEY REFERENCES Trainers(TrainerId) UNIQUE,
								BranchLocation NVARCHAR(40) NOT NULL,
								-- Putting a check on making sure that only one column has a value. We shouldn't have someone who is both a member and a trainer,
								-- so one column will be left empty (NULL).
								CHECK((MemberId IS NOT NULL AND TrainerId IS NULL) OR (MemberId IS NULL AND TrainerId IS NOT NULL)));

--ALTER TABLE Employees ADD Salary DECIMAL(10, 2);

--DELETE FROM Employees WHERE ID=100002;

--SELECT * FROM Employees;