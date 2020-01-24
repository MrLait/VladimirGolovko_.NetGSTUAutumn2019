CREATE PROCEDURE UpdateStudentSessionResults
@ID				INT = 0,
@StudentID      INT,
@ExamScheduleID INT,
@ExamValue		INT,
@SetOffValue	NVARCHAR(max)
AS
	UPDATE StudentSessionResults
	SET	StudentID = @StudentID, ExamScheduleID = @ExamScheduleID, ExamValue = @ExamValue, SetOffValue = @SetOffValue
	Where ID = @ID
--Selecting this Row
	SELECT * FROM StudentSessionResults WHERE ID = @ID
GO
