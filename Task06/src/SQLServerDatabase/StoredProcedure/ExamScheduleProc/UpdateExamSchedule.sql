CREATE PROCEDURE UpdateExamSchedule
@ID					INT = 0,
@NumberOfSession	INT,
@GroupID			INT,
@Subject            NVARCHAR(max),
@ExamDate           DATETIME,
@IsEstimated		NVARCHAR
AS
	UPDATE ExamSchedule
	SET	NumberOfSession = @NumberOfSession, GroupID = @GroupID, Subject = @Subject, ExamDate = @ExamDate, IsEstimated = @IsEstimated
	Where ID = @ID
--Selecting this Row
	SELECT * FROM ExamSchedule WHERE ID = @ID
GO
