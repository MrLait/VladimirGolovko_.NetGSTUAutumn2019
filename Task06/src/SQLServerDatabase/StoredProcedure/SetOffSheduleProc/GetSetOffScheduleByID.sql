CREATE PROCEDURE GetSetOffScheduleByID
	@ID INT
AS
	select * from SetOffSchedule where ID = @ID	
GO