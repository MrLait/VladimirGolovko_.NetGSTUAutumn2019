CREATE PROCEDURE UpdateStudent
@ID int = 0,
@Surname varchar(max),
@FirstName varchar(max),
@MiddleName varchar(max),
@Gender varchar(max),
@DateOfBirth DATETIME,
@GroupID int
AS
	UPDATE Student
	SET	Surname = @Surname, FirstName = @FirstName, MiddleName = @MiddleName, Gender = @Gender, DateOfBirth = @DateOfBirth, GroupID =  @GroupID
	Where ID = @ID
--Selecting this Row
	SELECT * FROM Student WHERE ID = @ID
GO

