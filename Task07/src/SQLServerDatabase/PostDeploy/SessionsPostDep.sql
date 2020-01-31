CREATE PROCEDURE SessionsPostDep
AS
DECLARE @number INT, @SessionsNum INT;
DECLARE @GroupNum INT;
SET @number = 1;
SET @SessionsNum = 1
WHILE @number <= @SessionsNum
	BEGIN

		INSERT INTO [Sessions]([Session])
		VALUES (@number);

		SET @number = @number + 1;

	END;
GO


