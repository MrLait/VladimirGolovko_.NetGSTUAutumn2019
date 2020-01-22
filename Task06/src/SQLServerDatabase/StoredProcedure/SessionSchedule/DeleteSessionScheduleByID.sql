CREATE PROCEDURE SessionScheduleByID
	@SessionScheduleID INT
AS
	DELETE FROM SessionSchedule WHERE SessionScheduleID = @SessionScheduleID	
GO
