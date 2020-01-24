CREATE PROCEDURE AddExamSchedule
@NumberOfSession   INT,
@GroupID           INT,
@Subject           NVARCHAR(max),
@ExamDate          DATETIME,
@IsEstimated       NVARCHAR(max)
AS 
    INSERT INTO ExamSchedule (NumberOfSession, GroupID, Subject, ExamDate, IsEstimated)
    VALUES (@NumberOfSession, @GroupID, @Subject, @ExamDate, @IsEstimated)
    
    SELECT SCOPE_IDENTITY()
Go

