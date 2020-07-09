CREATE PROCEDURE GetNumberOfSessionByID
	@ID INT
AS
	select * from [NumberOfSession] where ID = @ID	
GO