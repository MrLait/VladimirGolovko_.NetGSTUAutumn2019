CREATE PROCEDURE GetExamScheduleByID
	@ID INT
AS
	select * from ExamSchedule where ID = @ID	
GO