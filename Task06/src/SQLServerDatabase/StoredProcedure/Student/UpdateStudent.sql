CREATE PROCEDURE UpdateStudent
@StudentID int = 0,
@Surname varchar(max),
@FirstName varchar(max),
@MiddleName varchar(max),
@Gender varchar(max),
@DateOfBirth DATETIME,
@StudentGroup int
AS
	UPDATE Student
	SET	Surname = @Surname, FirstName = @FirstName, MiddleName = @MiddleName, Gender = @Gender, DateOfBirth = @DateOfBirth, StudentGroup =  @StudentGroup
	Where StudentID = @StudentID
--Selecting this Row
	SELECT * FROM Student WHERE StudentID = @StudentID
GO

