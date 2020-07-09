CREATE PROCEDURE AddNumberOfSession
@NumOfSession    INT
AS 
    INSERT INTO [dbo].[NumberOfSession] ([NumOfSession])
    VALUES (@NumOfSession)
    
    SELECT SCOPE_IDENTITY()
Go

