CREATE PROCEDURE ExaminersPostDep
AS
DECLARE @number INT, @numberOfExaminers INT;
DECLARE @Random INT;
DECLARE @SurnamePrefix NVARCHAR(40), @FirstNamePrefix NVARCHAR(40), @MiddleNamePrefix NVARCHAR(40);

SET @number = 1;
SET @SurnamePrefix = 'Surname';
SET @FirstNamePrefix = 'Firstname';
SET @MiddleNamePrefix = 'Middlename';
SET @numberOfExaminers = 1;
WHILE @number < 3 + 1
	BEGIN
		

		INSERT INTO Examiners(Surname, FirstName, MiddleName)
		VALUES (@SurnamePrefix + CONVERT(NVARCHAR, @number),
				@FirstNamePrefix + CONVERT(NVARCHAR, @number),
				@MiddleNamePrefix + CONVERT(NVARCHAR, @number));

		SET @number = @number + 1;

	END;
GO


