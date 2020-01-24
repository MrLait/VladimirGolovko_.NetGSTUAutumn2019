CREATE PROCEDURE GetGroupByID
	@ID INT
AS
	select * from [Group] where ID = @ID	
GO