USE JumpForFun;

SET DATEFORMAT DMY;

CREATE TABLE Trainers (TrainerId INT IDENTITY(1, 1) PRIMARY KEY,
								FName NVARCHAR(40) NOT NULL,
								LName NVARCHAR(40) NOT NULL,
								PhoneNo NVARCHAR(15) NOT NULL UNIQUE,
								Email NVARCHAR(320) NOT NULL UNIQUE,
								CreationDate DATE NOT NULL,
								CenterLocation NVARCHAR(15) NOT NULL);
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
								PhoneNo NVARCHAR(15) NOT NULL UNIQUE,
								Email NVARCHAR(320) NOT NULL UNIQUE,
								DateOfBirth DATE NOT NULL,
								CreationDate DATE NOT NULL,
								CenterLocation NVARCHAR(15) NOT NULL);
CREATE TABLE SubscriptionPlans (PlanId INT PRIMARY KEY,
								SubLevel NVARCHAR(15) NOT NULL);
CREATE TABLE Subscriptions (MemberId INT PRIMARY KEY,
								PlanId INT NOT NULL FOREIGN KEY REFERENCES SubscriptionPlans(PlanId),
								CreationDate DATE NOT NULL,
								ExpirationDate DATE NOT NULL);

-- Creating a new login for user,
-- creating a new role with execute and insert rights,
-- then finally assigning that role to the user.
--CREATE ROLE clerk;
--GRANT EXECUTE TO clerk;
--GRANT INSERT TO clerk;
--CREATE LOGIN frede WITH PASSWORD = 'mitKodeOrd';
--ALTER ROLE clerk ADD MEMBER frede;
--GO;

--CREATE TRIGGER TR_Check_Age_Requirement ON JumpForFun.Members
--AFTER INSERT  
--AS  
--IF (ROWCOUNT_BIG() = 0)
--RETURN;
--IF EXISTS (SELECT 6  
--           FROM inserted AS i 
--           WHERE DATEDIFF(month, i, CURRENT_TIMESTAMP) >= 12 * 18
--          )  
--BEGIN  
--RAISERROR ('A member must be at least 18 years of age!', 16, 1);  
--ROLLBACK TRANSACTION;  
--RETURN   
--END;
--GO;