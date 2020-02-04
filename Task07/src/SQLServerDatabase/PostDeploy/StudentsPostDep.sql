CREATE PROCEDURE StudentsPostDep
AS
DECLARE @QuantityGroups INT;
DECLARE @number INT;
DECLARE @Random INT;
DECLARE @StudentsNum INT;
DECLARE @SurnamePrefix NVARCHAR(40), @FirstNamePrefix NVARCHAR(40), @MiddleNamePrefix NVARCHAR(40),
@Gender NVARCHAR(40);

SET @QuantityGroups = (SELECT COUNT(*) FROM Groups) + 1;
SET @number = 1;
SET @StudentsNum = 12
SET @SurnamePrefix = 'Surname';
SET @FirstNamePrefix = 'Firstname';
SET @MiddleNamePrefix = 'Middlename';
WHILE @number < @StudentsNum + 1
	BEGIN

		--SET @Random = (FLOOR(RAND()*(@QuantitySpecialties-1)+1));
		IF (FLOOR(RAND()*(10-1)+1) < 5)
			SET @Gender = 'Male';
		ELSE
			SET @Gender = 'Female';
		
		SET @Random = (FLOOR(RAND()*(@QuantityGroups-1)+1));

		INSERT INTO Students(Surname, FirstName, MiddleName,Gender, DateOfBirth, GroupsID)
		VALUES (@SurnamePrefix + CONVERT(NVARCHAR, @number),
				@FirstNamePrefix + CONVERT(NVARCHAR, @number),
				@MiddleNamePrefix + CONVERT(NVARCHAR, @number),
				@Gender,
				DATEADD(DAY, -@number, GETDATE()),
				@Random);

		SET @number = @number + 1;

	END;
GO


