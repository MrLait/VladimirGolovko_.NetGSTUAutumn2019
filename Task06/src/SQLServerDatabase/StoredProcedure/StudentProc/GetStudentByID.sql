CREATE PROCEDURE GetStudentByID
	@ID INT
AS
	select * from [Student] where ID = @ID	
GO