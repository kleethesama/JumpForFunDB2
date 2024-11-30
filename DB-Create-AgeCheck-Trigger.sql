USE JumpForFun;

SET DATEFORMAT DMY;
GO

CREATE TRIGGER TR_Check_Age_Requirement ON dbo.Members
AFTER INSERT, UPDATE
AS  
IF (ROWCOUNT_BIG() = 0)
RETURN;
IF EXISTS (SELECT DateOfBirth
           FROM inserted
           WHERE DATEDIFF(month, DateOfBirth, GETDATE()) < 12 * 18
          )  
BEGIN  
RAISERROR ('A member must be at least 18 years of age!', 16, 1);  
ROLLBACK TRANSACTION;  
RETURN   
END;