CREATE PROCEDURE AddGroup
@NumberOfGroup    INT
AS 
    INSERT INTO [dbo].[Group] ([NumberOfGroup])
    VALUES (@NumberOfGroup)
    
    SELECT SCOPE_IDENTITY()
Go

