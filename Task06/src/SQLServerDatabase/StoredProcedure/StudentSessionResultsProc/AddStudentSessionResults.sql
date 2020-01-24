CREATE PROCEDURE AddStudentSessionResults
@StudentID      INT,
@ExamScheduleID INT,
@ExamValue      INT,
@SetOffValue    NVARCHAR(max)
AS 
    INSERT INTO StudentSessionResults (StudentID, ExamScheduleID, ExamValue, SetOffValue)
    VALUES (@StudentID, @ExamScheduleID, @ExamValue, @SetOffValue)
    
    SELECT SCOPE_IDENTITY()
Go

