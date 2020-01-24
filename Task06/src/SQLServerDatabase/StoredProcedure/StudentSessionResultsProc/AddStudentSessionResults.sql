CREATE PROCEDURE AddStudentSessionResults
@StudentID      INT,
@ExamScheduleID INT,
@ExamResult     INT,
@SetOffResult   NVARCHAR(max)
AS 
    INSERT INTO StudentSessionResults (StudentID, ExamScheduleID, ExamResult, SetOffResult)
    VALUES (@StudentID, @ExamScheduleID, @ExamResult, @SetOffResult)
    
    SELECT SCOPE_IDENTITY()
Go

