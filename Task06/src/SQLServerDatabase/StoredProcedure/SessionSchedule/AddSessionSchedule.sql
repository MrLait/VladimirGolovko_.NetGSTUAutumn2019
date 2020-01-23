CREATE PROCEDURE AddSessionSchedule
@NumberOfSession   INT,
@StudentGroup      INT,
@Subject           NVARCHAR(max),
@SetOffDate        DATETIME,
@ExamDate          DATETIME
AS 
    INSERT INTO SessionSchedule (NumberOfSession, StudentGroup, Subject, SetOffDate, ExamDate)
    VALUES (@NumberOfSession,@StudentGroup,@Subject,@SetOffDate,@ExamDate)
    
    SELECT SCOPE_IDENTITY()
Go

