CREATE PROCEDURE AddExamSchedule
@NumberOfSession   INT,
@GroupID           INT,
@Subject           NVARCHAR(max),
@ExamDate          DATETIME
AS 
    INSERT INTO ExamSchedule (NumberOfSession, GroupID, Subject, ExamDate)
    VALUES (@NumberOfSession, @GroupID, @Subject, @ExamDate)
    
    SELECT SCOPE_IDENTITY()
Go

