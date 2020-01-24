CREATE PROCEDURE UpdateStudentSessionResults
@ID				INT = 0,
@StudentID      INT,
@ExamScheduleID INT,
@ExamResult     INT,
@SetOffResult  NVARCHAR(max)
AS
	UPDATE StudentSessionResults
	SET	StudentID = @StudentID, ExamScheduleID = @ExamScheduleID, ExamResult = @ExamResult, SetOffResult = SetOffResult
	Where ID = @ID
--Selecting this Row
	SELECT * FROM StudentSessionResults WHERE ID = @ID
GO
