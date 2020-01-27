CREATE PROCEDURE GetStudentSessionResultsByID
	@ID INT
AS
	select * from StudentSessionResults where ID = @ID	
GO