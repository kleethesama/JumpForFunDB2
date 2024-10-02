USE JumpForFun;
GO

INSERT INTO Members (FName, LName, PhoneNo, Email, DateOfBirth, CreationDate)
VALUES ('John', 'Doe', '42415233', 'frk003@edu.zealand.dk', '01/05/1997', CURRENT_TIMESTAMP);

INSERT INTO Trainers (FName, LName, PhoneNo, Email, CreationDate)
VALUES ('Jens', 'Petersen', '+4555225315', 'jenbs@jumpforfun.com', CURRENT_TIMESTAMP);