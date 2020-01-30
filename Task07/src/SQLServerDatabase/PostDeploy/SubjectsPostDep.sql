CREATE PROCEDURE SubjectsPostDep
AS
DECLARE @QuantityExaminers INT;
DECLARE @number INT;
DECLARE @SybjectsPrefix NVARCHAR(40), @IsAssessment NVARCHAR(40);
DECLARE @Random INT;
DECLARE @GroupNum INT;
SET @QuantityExaminers = (SELECT COUNT(*) FROM Examiners);
SET @number = 1;
SET @SybjectsPrefix = 'Subject-';
SET @GroupNum = 3
SET @IsAssessment = 'True';
WHILE @number < (@QuantityExaminers*2 + 1)
	BEGIN

		SET @Random = (FLOOR(RAND()*(@QuantityExaminers-1)+1));

		INSERT INTO Subjects(SubjectName, IsAssessment,  ExaminersID)
		VALUES (@SybjectsPrefix + CONVERT(NVARCHAR, ROUND((@number + 1)/2 - 0.3,0)),
				@IsAssessment,
				ROUND((@number + 1)/2 - 0.3, 0));

		SET @number = @number + 1;

		IF (@number%2 = 0)
			SET @IsAssessment = 'False';
		ELSE
			SET @IsAssessment = 'True';
	END;
GO


