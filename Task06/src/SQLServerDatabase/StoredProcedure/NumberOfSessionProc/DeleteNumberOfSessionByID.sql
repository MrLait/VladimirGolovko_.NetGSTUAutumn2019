﻿CREATE PROCEDURE DeleteNumberOfSessionByID
	@ID INT
AS
	DELETE FROM [Group] WHERE ID = @ID
GO
