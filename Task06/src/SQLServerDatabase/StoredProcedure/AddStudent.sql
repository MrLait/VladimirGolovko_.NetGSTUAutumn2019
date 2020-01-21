CREATE PROCEDURE AddStudent
@Surname varchar(max),
@FirstName varchar(max),
@MiddleName varchar(max),
@Gender varchar(max),
@DateOfBirth DATETIME,
@StudentGroup int
AS 
    INSERT INTO Student (Surname, FirstName, MiddleName, Gender, DateOfBirth, StudentGroup)
    VALUES (@Surname,@FirstName,@MiddleName,@Gender,@DateOfBirth,@StudentGroup)
    
    SELECT SCOPE_IDENTITY()
Go
