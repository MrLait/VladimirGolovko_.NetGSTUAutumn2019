CREATE PROCEDURE UpdateSessionSchedule
@SessionScheduleID INT = 0,
@NumberOfSession   INT,
@StudentGroup      INT,
@Subject           NVARCHAR(max),
@SetOffDate        DATETIME,
@ExamDate          DATETIME
AS
	UPDATE SessionSchedule
	SET	NumberOfSession = @NumberOfSession, StudentGroup = @StudentGroup, Subject = @Subject, SetOffDate = @SetOffDate, ExamDate = @ExamDate
	Where SessionScheduleID = @SessionScheduleID
--Selecting this Row
	SELECT * FROM SessionSchedule WHERE SessionScheduleID = @SessionScheduleID
GO
