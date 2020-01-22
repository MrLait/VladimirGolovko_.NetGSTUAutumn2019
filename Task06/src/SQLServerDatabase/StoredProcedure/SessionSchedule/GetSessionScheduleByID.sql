CREATE PROCEDURE GetSessionScheduleByID
	@SessionScheduleID INT
AS
	select * from [SessionSchedule] where SessionScheduleID = @SessionScheduleID	
GO