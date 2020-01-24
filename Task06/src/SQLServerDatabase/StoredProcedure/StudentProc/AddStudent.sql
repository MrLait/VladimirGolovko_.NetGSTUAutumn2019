CREATE PROCEDURE AddStudent
@Surname varchar(max),
@FirstName varchar(max),
@MiddleName varchar(max),
@Gender varchar(max),
@DateOfBirth DATETIME,
@GroupID int
AS 
    INSERT INTO Student (Surname, FirstName, MiddleName, Gender, DateOfBirth, GroupID)
    VALUES (@Surname,@FirstName,@MiddleName,@Gender,@DateOfBirth,@GroupID)
    
    SELECT SCOPE_IDENTITY()
Go
