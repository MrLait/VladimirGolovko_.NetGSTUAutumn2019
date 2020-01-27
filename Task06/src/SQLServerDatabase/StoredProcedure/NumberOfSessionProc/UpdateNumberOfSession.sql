CREATE PROCEDURE UpdateNumberOfSession
@ID				INT = 0,
@NumOfSession	INT
AS
	UPDATE [NumberOfSession]
	SET	NumOfSession = @NumOfSession
	Where ID = @ID
--Selecting this Row
	SELECT * FROM [NumberOfSession] WHERE ID = @ID
GO
