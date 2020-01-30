CREATE PROCEDURE DeleteStudentSessionResultsByID
	@ID INT
AS
	DELETE FROM StudentSessionResults WHERE ID = @ID
GO
