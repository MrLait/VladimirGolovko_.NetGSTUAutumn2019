CREATE PROCEDURE AddSetOffSchedule
@NumberOfSession    INT,
@GroupID            INT,
@Subject            NVARCHAR(max),
@SetOffDate         DATETIME
AS 
    INSERT INTO SetOffSchedule (NumberOfSession, GroupID, Subject, SetOffDate)
    VALUES (@NumberOfSession, @GroupID, @Subject, @SetOffDate)
    
    SELECT SCOPE_IDENTITY()
Go

