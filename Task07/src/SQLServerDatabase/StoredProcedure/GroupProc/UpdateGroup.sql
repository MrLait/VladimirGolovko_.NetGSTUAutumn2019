CREATE PROCEDURE UpdateGroup
@ID				INT = 0,
@NumberOfGroup	INT
AS
	UPDATE [Group]
	SET	NumberOfGroup = @NumberOfGroup
	Where ID = @ID
--Selecting this Row
	SELECT * FROM [Group] WHERE ID = @ID
GO
