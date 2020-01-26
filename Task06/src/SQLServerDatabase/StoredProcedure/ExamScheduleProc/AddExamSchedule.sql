CREATE PROCEDURE AddExamSchedule
@NumberOfSessionID   INT,
@GroupID           INT,
@Subject           NVARCHAR(max),
@ExamDate          DATETIME,
@IsEstimated       NVARCHAR(max)
AS 
    INSERT INTO ExamSchedule (NumberOfSessionID, GroupID, Subject, ExamDate, IsEstimated)
    VALUES (@NumberOfSessionID, @GroupID, @Subject, @ExamDate, @IsEstimated)
    
    SELECT SCOPE_IDENTITY()
Go

