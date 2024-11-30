USE JumpForFun;

INSERT INTO SubscriptionPlans (PlanId, SubLevel)
VALUES
(1, 'Basic'),
(2, 'Enhanced'),
(3, 'Premium');

INSERT INTO Members (FName, LName, PhoneNo, Email, DateOfBirth, CreationDate, CenterLocation)
VALUES ('Frederik', 'Klee', '42415233', 'frk003@edu.zealand.dk', '01/05/1997', CURRENT_TIMESTAMP, 'Roskilde');

INSERT INTO Subscriptions (MemberId, PlanId, CreationDate, ExpirationDate)
VALUES (100000, 3, CURRENT_TIMESTAMP, '02/10/2025');

INSERT INTO Trainers (FName, LName, PhoneNo, Email, CreationDate, CenterLocation)
VALUES ('Jens', 'Petersen', '+4555225315', 'jens@jumpforfun.com', CURRENT_TIMESTAMP, 'Roskilde');