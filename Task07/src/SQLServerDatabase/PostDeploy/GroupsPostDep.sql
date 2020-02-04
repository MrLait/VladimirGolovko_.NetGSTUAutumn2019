CREATE PROCEDURE GroupsPostDep
AS
DECLARE @QuantitySpecialties INT;
DECLARE @number INT;
DECLARE @GroupPrefix NVARCHAR(40);
DECLARE @Random INT;
DECLARE @GroupNum INT;
SET @QuantitySpecialties = (SELECT COUNT(*) FROM Specialties) + 1;
SET @number = 1;
SET @GroupPrefix = 'PM-';
SET @GroupNum = 4
WHILE @number < @GroupNum + 1
	BEGIN

		SET @Random = (FLOOR(RAND()*(@QuantitySpecialties-1)+1));

		INSERT INTO Groups ([GroupName], SpecialtiesID)
		VALUES (@GroupPrefix + CONVERT(NVARCHAR, @number),
				@Random);

		SET @number = @number + 1;

	END;
GO


