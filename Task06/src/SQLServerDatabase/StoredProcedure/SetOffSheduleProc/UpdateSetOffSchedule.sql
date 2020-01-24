CREATE PROCEDURE UpdateSetOffSchedule
@ID					INT = 0,
@NumberOfSession	INT,
@GroupID			INT,
@Subject            NVARCHAR(max),
@SetOffDate			DATETIME
AS
	UPDATE SetOffSchedule
	SET	NumberOfSession = @NumberOfSession, GroupID = @GroupID, Subject = @Subject, SetOffDate = @SetOffDate
	Where ID = @ID
--Selecting this Row
	SELECT * FROM SetOffSchedule WHERE ID = @ID
GO
