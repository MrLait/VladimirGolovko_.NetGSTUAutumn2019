CREATE PROCEDURE DeleteStudentByID
	@StudentID INT
AS
	DELETE FROM Student WHERE StudentID = @StudentID	
GO
