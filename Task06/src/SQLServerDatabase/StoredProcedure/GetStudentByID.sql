CREATE PROCEDURE GetStudentByID
	@StudentID INT
AS
	select * from [Student] where StudentID = @StudentID	
GO